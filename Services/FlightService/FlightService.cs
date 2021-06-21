using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlightManagement.Data;
using FlightManagement.DTOs.FlightNumber;
using FlightManagement.Extentions;
using FlightManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Services.FlightService
{
    public class FlightService : IFlightService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public FlightService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetFlightDto>>> AddFlight(AddFlightDto newFlight)
        {
            var serviceResponse = new ServiceResponse<List<GetFlightDto>>();
            Flight flightNumber = _mapper.Map<Flight>(newFlight);
            _context.Flights.Add(flightNumber);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Flights.Select(e => _mapper.Map<GetFlightDto>(e)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<object>>> GetAllAvailableFlightInRange(DateTime startDate, DateTime endDate, int noOfPax)
        {
            var serviceResponse = new ServiceResponse<List<object>>();
            serviceResponse.Data = new List<object>();
            for (DateTime chkDate = startDate; chkDate <= endDate; chkDate = chkDate.AddDays(1))
            {
                var res = new ServiceResponse<List<GetFlightDto>>();
                res.Data = new List<GetFlightDto>();
                List<Flight> availableFlights = await _context.Flights.ToListAsync<Flight>();
                List<int> unavaiFlightID = new List<int>();
                if (chkDate.DayOfYear < DateTime.Now.DayOfYear)
                {
                    continue;
                } else if (chkDate.DayOfYear == DateTime.Now.DayOfYear)
                {
                    List<Flight> temps = new List<Flight>();
                    temps = availableFlights;
                    availableFlights.ForEach(avaFlight => {
                        DateTime flightTime = DateTime.ParseExact(avaFlight.StartTime, "HHmmss", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime now = DateTime.Now;
                        if (flightTime.Hour < now.Hour)
                        {
                            unavaiFlightID.Add(avaFlight.FlightID);
                        } else if (flightTime.Hour == now.Hour)
                        {
                            if(flightTime.Minute < now.Minute)
                            {
                                unavaiFlightID.Add(avaFlight.FlightID);
                            }
                        }
                    });
                } 
                var flightIDs = availableFlights.Select(e => e.FlightID).Distinct().ToList();
                var bookings = _context.Bookings.Where(e => e.CreatedDate.DayOfYear == chkDate.DayOfYear).ToList();
                
                flightIDs.ForEach(flightID => {
                    int bookedPax = 0;
                    var flightBookings = bookings.Where(e => e.FlightID == flightID).ToList();
                    flightBookings.ForEach(booking => {
                        bookedPax += booking.NoOfPax;
                    });
                    
                    var flightCapacity = availableFlights.Where(e => e.FlightID == flightID).FirstOrDefault();
                    if (flightCapacity != null && noOfPax < (flightCapacity.PassengerCapacity - bookedPax))
                    {
                        
                    } else 
                    {
                        unavaiFlightID.Add(flightCapacity.FlightID);
                    }
                });

                availableFlights = availableFlights.Where(e => !unavaiFlightID.Contains(e.FlightID)).ToList();
                availableFlights.ForEach(avaFlight => {
                    res.Data.Add(new GetFlightDto {
                        FlightNumber = avaFlight.FlightNumber,
                        StartTime = chkDate.ToString("yyyy-MM-dd ") + avaFlight.StartTime.ConvertToTime("HHmmss", "HH:mm"),
                        EndTime = chkDate.ToString("yyyy-MM-dd ") + avaFlight.EndTime.ConvertToTime("HHmmss", "HH:mm"),
                        PassengerCapacity = avaFlight.PassengerCapacity,
                        DeparterCity = avaFlight.DeparterCity,
                        ArrivalCity = avaFlight.ArrivalCity
                    });
                });
                serviceResponse.Data.Add(new {
                    date = chkDate.ToString("yyyy-MM-dd"),
                    Available = res.Data
                });
            }

            if (!serviceResponse.Data.Any())
            {
                serviceResponse.Message = "There is no available flight in the range time. Pls try another timestamps search.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetFlightDto>>> GetAllFlights()
        {
            var serviceResponse = new ServiceResponse<List<GetFlightDto>>();
            var dbFlights = await _context.Flights.ToListAsync();
            serviceResponse.Data = dbFlights.Select(e => _mapper.Map<GetFlightDto>(e)).ToList();

            return serviceResponse;
        }
    }
}