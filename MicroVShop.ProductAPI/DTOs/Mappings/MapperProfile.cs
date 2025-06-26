using AutoMapper;
using MicroVShop.Models;
namespace MicroVShop.DTOs.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryProductsDTO>().ReverseMap();
        }
    }
}