using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightManagement.DTOs.FlightNumber;
using FlightManagement.Models;
using FlightManagement.Services.FlightService;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightManagementController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightManagementController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetFlightDto>>>> Get()
        {
            return Ok(await _flightService.GetAllFlights());
        }

        [HttpGet("GetAvailable")]
        public async Task<ActionResult<ServiceResponse<List<object>>>> GetAvailable(DateTime startDate, DateTime endDate, int noOfPax)
        {
            return Ok(await _flightService.GetAllAvailableFlightInRange(startDate, endDate, noOfPax));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetFlightDto>>>> AddFlight(AddFlightDto newFlight)
        {
            
            return Ok(await _flightService.AddFlight(newFlight));
        }
    }
}