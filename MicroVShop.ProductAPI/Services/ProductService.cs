using AutoMapper;
using MicroVShop.DTOs;
using MicroVShop.Models;
using MicroVShop.Repositories;

namespace MicroVShop.Services;

public class ProductService : BaseService<Product, ProductDto>, IProductService 
{
    public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper)
    { }
}