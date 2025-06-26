namespace MicroVShop.Services
{
    public interface IBaseService<TDto>
        where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> CreateAsync(TDto dto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(int id);
    }
}