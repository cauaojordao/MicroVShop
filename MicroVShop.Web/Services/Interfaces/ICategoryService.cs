using MicroVShop.Web.Models;

namespace MicroVShop.Web.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAllAsync();
}