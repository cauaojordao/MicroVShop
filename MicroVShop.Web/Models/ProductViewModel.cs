using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroVShop.Web.Models;

public class ProductViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do produto deve ter no máximo 100 caracteres.")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "O preço do produto é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
    [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "O estoque do produto é obrigatório.")]
    [Range(0, long.MaxValue, ErrorMessage = "O estoque não pode ser negativo.")]
    public long Stock { get; set; }
    
    [Required(ErrorMessage = "A URL da imagem é obrigatória.")]
    [StringLength(500, ErrorMessage = "A URL da imagem deve ter no máximo 500 caracteres.")]
    [Url(ErrorMessage = "A URL da imagem não é válida.")]
    public string? ImageURL { get; set; }
    public string? CategoryName { get; set; }
    
    [Required(ErrorMessage = "O ID da categoria é obrigatório.")]
    public int CategoryId { get; set; }
}