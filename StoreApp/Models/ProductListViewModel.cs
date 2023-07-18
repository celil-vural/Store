using Entities.Models;

namespace StoreApp.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public Pagination Pagination { get; set; } = new();
        public int TotalCount => Products.Count;
    }
}
