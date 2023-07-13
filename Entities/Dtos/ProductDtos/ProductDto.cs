using Entities.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.ProductDtos
{
    public record class ProductDto : IDto
    {
        public int ProductId { get; init; }
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; init; } = string.Empty;
        [Required(ErrorMessage = "Supplier id is required")]
        public int SupplierId { get; init; }
        [Required(ErrorMessage = "Category id is required")]
        public int CategoryId { get; init; }
        [Required(ErrorMessage = "Product quantity per unit is required")]
        public string QuantityPerUnit { get; init; } = string.Empty;
        [Required(ErrorMessage = "Product Price is required")]
        public string? ImageUrl { get; set; }
        public decimal UnitPrice { get; init; }
        [Required(ErrorMessage = "Product Stock is required")]
        public short UnitsInStock { get; init; }
        [Required(ErrorMessage = "Product Units On Order is required")]
        public short UnitsOnOrder { get; init; }
        [Required(ErrorMessage = "Product Record Level is required")]
        public short ReorderLevel { get; init; }
    }
}
