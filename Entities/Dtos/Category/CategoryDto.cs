using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.Category
{
    public record CategoryDto
    {
        public int CategoryId { get; init; }
        [Required(ErrorMessage = "Category name is required")]
        public string? CategoryName { get; init; } = string.Empty;
    }
}
