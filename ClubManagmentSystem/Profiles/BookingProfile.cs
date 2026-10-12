using AutoMapper;
using ClubManagmentSystem.DTO_s;
using ClubManagmentSystem.Models;

namespace ClubManagmentSystem.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile() { 
            CreateMap<Booking, GetBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
        }
    }
}
