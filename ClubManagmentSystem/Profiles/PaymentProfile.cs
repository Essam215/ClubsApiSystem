using AutoMapper;
using ClubManagmentSystem.DTO_s;
using ClubManagmentSystem.Models;

namespace ClubManagmentSystem.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile() { 
            CreateMap<CreatePaymentDto, Payment>().ReverseMap();
            CreateMap<UpdatePaymentDto, Payment>().ReverseMap();
            CreateMap<GetPaymentDto, Payment>().ReverseMap();
        }
    }
}
