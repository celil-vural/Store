using Entities.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.CategoryDtos
{
    public class CategoryDto : IDto
    {
        public int CategoryId { get; init; }
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; init; } = String.Empty;
        [Required(ErrorMessage = "Description Name is required")]
        public string Description { get; init; } = String.Empty;
        public string? PictureUrl { get; set; }
        public byte[] Picture { get; init; }
    }
}
