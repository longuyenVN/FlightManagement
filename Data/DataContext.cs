using System;
using FlightManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuild)
        {
            modelBuild.Entity<Flight>().HasData(
                new Flight { FlightID = 1, StartTime = DateTime.Now.ToString("HHmmss"), EndTime = DateTime.Now.AddHours(1).AddMinutes(30).ToString("HHmmss"), PassengerCapacity = 10, DeparterCity = "Danang", ArrivalCity = "Tp.Hochiminh", IsAvailable = true, FlightNumber = "VN117" },
                new Flight { FlightID = 2, StartTime = DateTime.Now.ToString("HHmmss"), EndTime = DateTime.Now.AddHours(2).AddMinutes(30).ToString("HHmmss"), PassengerCapacity = 5, DeparterCity = "Danang", ArrivalCity = "Phuquoc", IsAvailable = true, FlightNumber = "VN399" }
            );
        }
    }
}