using AutoMapper;
using Entities.Dtos.CategoryDtos;
using Entities.Dtos.ProductDtos;
using Entities.Models;

namespace StoreApp.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<CategoryDtoForUpdate, Category>().ReverseMap();
            CreateMap<CategoryDtoForInsertion, Category>();
        }
    }
}
