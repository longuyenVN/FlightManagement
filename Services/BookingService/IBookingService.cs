using System.Collections.Generic;
using System.Threading.Tasks;
using FlightManagement.DTOs.Booking;
using FlightManagement.Models;

namespace FlightManagement.Services.BookingService
{
    public interface IBookingService
    {
        Task<ServiceResponse<List<GetBookingDto>>> AddBooking(AddBookingDto newBooking);

        Task<ServiceResponse<List<GetBookingDto>>> SearchBooking(SearchBooking searchBooking);
    }
}