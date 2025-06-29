using MicroVShop.Web.Models;

namespace MicroVShop.Web.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync();
    Task<ProductViewModel?> GetByIdAsync(int id);
    Task<ProductViewModel?> CreateAsync(ProductViewModel product);
    Task<bool> UpdateAsync(ProductViewModel product);
    Task<bool> DeleteAsync(int id);
}