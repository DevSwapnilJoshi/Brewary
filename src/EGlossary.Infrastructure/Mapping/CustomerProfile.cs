using AutoMapper;
using EGlossary.Domain.Entities;

namespace EGlossary.Infrastructure.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Service.Models.CustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId))
                .ReverseMap();
        }
    }
}