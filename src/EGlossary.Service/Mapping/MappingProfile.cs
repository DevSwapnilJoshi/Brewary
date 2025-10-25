using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Persistence.DataModels;
using EGlossary.Service.Models;

namespace EGlossary.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, CustomerEntity>();
            CreateMap<CustomerEntity, CustomerDataModel>().ReverseMap();

            CreateMap<ProductDto, ProductEntity>();
            CreateMap<ProductEntity, ProductDataModel>().ReverseMap();

            CreateMap<OrderDto, OrderEntity>();
            CreateMap<OrderEntity, OrderDataModel>().ReverseMap();

            CreateMap<CategoryDto, CategoryEntity>();
            CreateMap<CategoryEntity, CategoryDataModel>().ReverseMap();

            CreateMap<BreweryDto, BreweryEntity>();
            CreateMap<BreweryEntity, BreweryDataModel>().ReverseMap();
        }
    }
}