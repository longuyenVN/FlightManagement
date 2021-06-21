using System.Collections.Generic;
using System.Threading.Tasks;
using FlightManagement.DTOs.Booking;
using FlightManagement.Models;
using FlightManagement.Services.BookingService;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetBookingDto>>>> AddBooking(AddBookingDto newBooking)
        {
            return Ok(await _bookingService.AddBooking(newBooking));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetBookingDto>>>> AddBooking(SearchBooking searchBooking)
        {
            return Ok(await _bookingService.SearchBooking(searchBooking));
        }
    }
}