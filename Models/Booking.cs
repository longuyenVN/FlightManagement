using System;

namespace FlightManagement.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        public string PassengerName { get; set; }

        public int FlightID { get; set; }

        public int NoOfPax { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime ReservationDate { get; set; }
    }
}