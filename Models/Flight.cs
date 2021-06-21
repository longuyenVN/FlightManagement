using System;
using System.Collections.Generic;

namespace FlightManagement.Models
{
    public class Flight
    {
        public int FlightID { get; set; } = 1;

        public string StartTime { get; set; } = "";

        public string FlightNumber { get; set; }

        public string EndTime { get; set; } = "";

        public int PassengerCapacity {get;set;} = 200;

        public string DeparterCity { get; set; } = "Hanoi";

        public string  ArrivalCity { get; set; } = "Saigon";
        
        public bool IsAvailable { get; set; } = true;
    }
}