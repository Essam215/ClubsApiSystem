using AutoMapper;
using ClubManagmentSystem.DTO_s;
using ClubManagmentSystem.Models;

namespace ClubManagmentSystem.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile() {
            CreateMap<Member, CreateMemberDto>().ReverseMap();
            CreateMap<Member, GetMemberDto>().ReverseMap();
            CreateMap<Member, UpdateMemberDto>().ReverseMap();
        }
    }
}
