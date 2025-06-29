using MicroVShop.DTOs;

namespace MicroVShop.Services
{
    public interface ICategoryService : IBaseService<CategoryDto>
    {
        Task<CategoryProductsDTO> GetCategoryProductsAsync(int categoryId);
    }
}