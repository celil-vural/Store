using Entities.Models;
using StoreApp.Infrastructe.Extensions;
using System.Text.Json.Serialization;

namespace StoreApp.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session ?? throw new NullReferenceException();
            var cart = session.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Product product, short quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("Cart");
        }

        public override void RemoveItem(int productId)
        {
            base.RemoveItem(productId);
            Session?.SetJson("Cart", this);
        }
        public override void RemoveLine(OrderDetail orderDetail)
        {
            base.RemoveLine(orderDetail);
            Session?.SetJson("Cart", this);
        }
    }
}
