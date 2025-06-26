using Microsoft.EntityFrameworkCore;
using MicroVShop.Context;
using MicroVShop.Models;

namespace MicroVShop.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryProductsAsync(int categoryId)
        {
            return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}