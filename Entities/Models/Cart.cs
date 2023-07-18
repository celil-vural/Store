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
        public virtual void AddItem(Product product, short quantity)
        {
            var line = Lines
                .FirstOrDefault(p => p.Product.ProductId.Equals(product.ProductId));
            if (line is null)
            {
                Lines.Add(new CartLine()
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

        public virtual void RemoveItem(int productId)
        {
            var line = Lines
                .FirstOrDefault(p => p.Product.ProductId.Equals(productId));
            if (line is not null)
            {
                if (line.Quantity <= 1)
                {
                    RemoveLine(new CartLine() { Product = new Product() { ProductId = productId } });
                }
                else
                {
                    line.Quantity -= 1;
                }
            }

        }
        public virtual void RemoveLine(CartLine cartLine) =>
            Lines.RemoveAll(l => l.Product.ProductId.Equals(cartLine.Product.ProductId));
        public virtual decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
}
