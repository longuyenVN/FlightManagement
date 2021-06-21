using AutoMapper;
using FlightManagement.DTOs.Booking;
using FlightManagement.DTOs.FlightNumber;
using FlightManagement.Extentions;
using FlightManagement.Models;

namespace FlightManagement
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Flight, GetFlightDto>().ForMember(d => d.StartTime, t => t.MapFrom(s => s.StartTime.ConvertToTime("HHmmss", "HH:mm")))
                .ForMember(d => d.EndTime, t => t.MapFrom(s => s.EndTime.ConvertToTime("HHmmss", "HH:mm")));
            CreateMap<AddFlightDto, Flight>();
            CreateMap<AddBookingDto, Booking>();
            CreateMap<Booking, GetBookingDto>();
        }
    }
}