using Entities.Contracts;

namespace Entities.Models
{
    public class CartLine : IEntity
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}
