using Entities.Models;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static List<Product> FilteredProductsByCategorId(this IList<Product> products, int? categoryId)
        {
            if (categoryId is null)
            {
                return products.ToList();
            }
            return products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public static List<Product> FilteredProductsBySearchTerm(this IList<Product> products, string? searchTerm)
        {
            return string.IsNullOrWhiteSpace(searchTerm) ? products.ToList() : products.Where(p => p.ProductName.ToLower().Contains(searchTerm.Trim().ToLower())).ToList();
        }

        public static List<Product> FilterByPriceRange(this IList<Product> products, decimal minPrice, decimal? maxPrice, bool isValidPriceRange)
        {
            return isValidPriceRange ? products.Where(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice).ToList() : products.ToList();
        }
    }
}
