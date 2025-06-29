using AutoMapper;
using MicroVShop.Models;

namespace MicroVShop.DTOs.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryProductsDTO>().ReverseMap();
        }
    }
}