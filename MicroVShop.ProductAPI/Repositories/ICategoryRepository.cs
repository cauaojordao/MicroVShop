using MicroVShop.Models;

namespace MicroVShop.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category> GetCategoryProductsAsync(int categoryId);
}