using Entities.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class OrderDetail : IEntity
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }
        [NotMapped]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public short Quantity { get; set; }

        [Required]
        public float Discount { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
