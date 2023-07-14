using Entities.Contracts;

namespace Entities.Models
{
    public class Cart : IEntity
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public virtual void AddItem(Product product, int quantity)
        {
            var line = Lines
                .FirstOrDefault(p => p.Product.ProductId.Equals(product.ProductId));
            if (line is null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Product product) =>
            Lines.RemoveAll(l => l.Product.ProductId.Equals(product.ProductId));
        public virtual decimal ComputeTotalValue() => Lines.Sum(e => e.Product.UnitPrice * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
}
