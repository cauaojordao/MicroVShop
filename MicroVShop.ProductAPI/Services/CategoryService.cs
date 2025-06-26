using AutoMapper;
using MicroVShop.DTOs;
using MicroVShop.Models;
using MicroVShop.Repositories;

namespace MicroVShop.Services;

public class CategoryService : BaseService<Category , CategoryDto>, ICategoryService 
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        : base(categoryRepository, mapper)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryProductsDTO> GetCategoryProductsAsync(int categoryId)
    {
        var category = await _categoryRepository.GetCategoryProductsAsync(categoryId);
        return _mapper.Map<CategoryProductsDTO>(category);
    }
}