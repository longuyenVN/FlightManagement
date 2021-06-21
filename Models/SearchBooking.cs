using System;

namespace FlightManagement.Models
{
    public class SearchBooking
    {
        public string PassengerName { get; set; }
        
        public DateTime Date { get; set; }

        public string  ArrivalCity { get; set; }

        public string DepartureCity { get; set; }
        
        public int FlightNumber { get; set; }
    }
}