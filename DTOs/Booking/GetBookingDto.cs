using System;

namespace FlightManagement.DTOs.Booking
{
    public class GetBookingDto
    {
        public string FlightNumber { get; set; }

        public string PassengerName { get; set; }

        public int NoOfPax { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string DeparterCity { get; set; }

        public string  ArrivalCity { get; set; }
    }
}