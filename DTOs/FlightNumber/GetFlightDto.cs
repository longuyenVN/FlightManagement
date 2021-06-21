using System;

namespace FlightManagement.DTOs.FlightNumber
{
    public class GetFlightDto
    {
        public string FlightNumber { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int PassengerCapacity {get;set;}

        public string DeparterCity { get; set; }

        public string  ArrivalCity { get; set; }
    }
}