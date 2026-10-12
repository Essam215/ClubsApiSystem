using AutoMapper;
using ClubManagmentSystem.DTO_s;
using ClubManagmentSystem.Models;

namespace ClubManagmentSystem.Profiles
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile() {
            CreateMap<Facility, CreateFacilityDto>().ReverseMap();
            CreateMap<Facility, UpdateFacilityDto>().ReverseMap();
            CreateMap<Facility, GetFacilityDto>().ReverseMap();
        }
    }
}
