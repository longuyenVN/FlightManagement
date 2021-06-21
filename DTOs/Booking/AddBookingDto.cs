using System;

namespace FlightManagement.DTOs.Booking
{
    public class AddBookingDto
    {
        public string PassengerName { get; set; }

        public int FlightID { get; set; }

        public int NoOfPax { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}