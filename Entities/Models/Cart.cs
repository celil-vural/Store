using Entities.Contracts;

namespace Entities.Models
{
    public class Cart : IEntity
    {
        public List<OrderDetail> Lines { get; set; }
        public Cart()
        {
            Lines = new List<OrderDetail>();
        }
        public virtual void AddItem(Product product, short quantity)
        {
            var line = Lines
                .FirstOrDefault(p => p.ProductId.Equals(product.ProductId));
            if (line is null)
            {
                Lines.Add(new OrderDetail()
                {
                    ProductId = product.ProductId,
                    UnitPrice = product.UnitPrice,
                    Discount = 0,
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
                .FirstOrDefault(p => p.ProductId.Equals(productId));
            if (line is not null)
            {
                if (line.Quantity <= 1)
                {
                    RemoveLine(new OrderDetail() { ProductId = productId });
                }
                else
                {
                    line.Quantity -= 1;
                }
            }

        }
        public virtual void RemoveLine(OrderDetail order) =>
            Lines.RemoveAll(l => l.ProductId.Equals(order.ProductId));
        public virtual decimal ComputeTotalValue() => Lines.Sum(e => e.UnitPrice * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
}
