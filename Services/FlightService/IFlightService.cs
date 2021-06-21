using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightManagement.DTOs.FlightNumber;
using FlightManagement.Models;

namespace FlightManagement.Services.FlightService
{
    public interface IFlightService
    {
        Task<ServiceResponse<List<GetFlightDto>>> GetAllFlights();

        Task<ServiceResponse<List<object>>> GetAllAvailableFlightInRange(DateTime startDate, DateTime endDate, int noOfPax);

        Task<ServiceResponse<List<GetFlightDto>>> AddFlight(AddFlightDto newFlight);
    }
}