using System.ComponentModel.DataAnnotations;

namespace MicroVShop.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da categoria deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }
        
    }
}