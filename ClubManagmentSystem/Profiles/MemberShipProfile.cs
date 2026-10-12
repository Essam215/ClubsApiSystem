using AutoMapper;
using ClubManagmentSystem.DTO_s;
using ClubManagmentSystem.Models;

namespace ClubManagmentSystem.Profiles
{
    public class MemberShipProfile : Profile
    {
        public MemberShipProfile() { 
            CreateMap<MemberShip, CreateMemberShipDto>().ReverseMap();
            CreateMap<MemberShip, UpdateMemberShipDto>().ReverseMap();
            CreateMap<MemberShip, GetMemberShipDto>().ReverseMap();
        }
    }
}
