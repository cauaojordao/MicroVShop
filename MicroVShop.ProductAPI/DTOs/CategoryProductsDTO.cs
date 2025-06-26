namespace MicroVShop.DTOs;

public class CategoryProductsDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<ProductDto> Products { get; set; }
}