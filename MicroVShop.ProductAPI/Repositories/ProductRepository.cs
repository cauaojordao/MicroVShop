using MicroVShop.Context;
using MicroVShop.Models;

namespace MicroVShop.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }
}