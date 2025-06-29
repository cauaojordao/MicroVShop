using Microsoft.EntityFrameworkCore;
using MicroVShop.Context;
using MicroVShop.Models;

namespace MicroVShop.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.Include(p => p.Category)
            .ToListAsync();
    }
    
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}