using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlightManagement.Data;
using FlightManagement.DTOs.Booking;
using FlightManagement.Extentions;
using FlightManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookingService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetBookingDto>>> AddBooking(AddBookingDto newBooking)
        {
            var serviceResponse = new ServiceResponse<List<GetBookingDto>>();

            var flight = await _context.Flights.Where(e => e.FlightID == newBooking.FlightID).FirstOrDefaultAsync();

            if (newBooking.CreatedDate.DayOfYear < DateTime.Now.DayOfYear)
            {
                serviceResponse.Message = "Invalid reservation date.";
                return serviceResponse;
            } else if (newBooking.CreatedDate.DayOfYear == DateTime.Now.DayOfYear)
            {
                DateTime flightTime = DateTime.ParseExact(flight.StartTime, "HHmmss", System.Globalization.CultureInfo.InvariantCulture);
                if (flightTime.Hour < DateTime.Now.Hour)
                {
                    serviceResponse.Message = "Invalid reservation date and time.";
                    return serviceResponse;
                } else if (flightTime.Hour == DateTime.Now.Hour)
                {
                    if (flightTime.Minute < DateTime.Now.Minute)
                    {
                        serviceResponse.Message = "Invalid reservation date and time.";
                        return serviceResponse;
                    }
                }
            }

            List<Booking> bookings = await _context.Bookings.Where(e => e.FlightID == newBooking.FlightID && e.CreatedDate.DayOfYear == newBooking.CreatedDate.DayOfYear).ToListAsync();
            int noOfPaxBooked = 0;
            bookings.ForEach(booking => {
                noOfPaxBooked += booking.NoOfPax;
            });

            if (flight != null)
            {
                if ((flight.PassengerCapacity - noOfPaxBooked) >= newBooking.NoOfPax)
                {
                    Booking newEntity = _mapper.Map<Booking>(newBooking);
                    _context.Bookings.Add(newEntity);
                    await _context.SaveChangesAsync();

                    List<GetBookingDto> res = new List<GetBookingDto>();
                    res.Add(new GetBookingDto {
                        FlightNumber = flight.FlightNumber,
                        PassengerName = newEntity.PassengerName,
                        NoOfPax = newEntity.NoOfPax,
                        StartTime = newEntity.CreatedDate.ToString("yyyyMMdd ") + flight.StartTime.ConvertToTime(),
                        EndTime = newEntity.CreatedDate.ToString("yyyyMMdd") + flight.EndTime.ConvertToTime(),
                        DeparterCity = flight.DeparterCity,
                        ArrivalCity = flight.ArrivalCity
                    });
                    serviceResponse.Data = res;
                    return serviceResponse;
                }
            }

            serviceResponse.Message = "There is no available number of required Pax.";   
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBookingDto>>> SearchBooking(SearchBooking searchBooking)
        {
            throw new System.NotImplementedException();
        }
    }
}