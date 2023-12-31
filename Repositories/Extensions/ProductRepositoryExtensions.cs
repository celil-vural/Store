﻿using Entities.Models;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IEnumerable<Product> FilteredProductsByCategorId(this IEnumerable<Product> products, int? categoryId)
        {
            if (categoryId is null)
            {
                return products.ToList();
            }
            return products.Where(p => p.CategoryId == categoryId);
        }

        public static IEnumerable<Product> FilteredProductsBySearchTerm(this IEnumerable<Product> products, string? searchTerm)
        {
            return string.IsNullOrWhiteSpace(searchTerm) ? products : products.Where(p => p.ProductName.ToLower().Contains(searchTerm.Trim().ToLower()));
        }

        public static IEnumerable<Product> FilterByPriceRange(this IEnumerable<Product> products, decimal minPrice, decimal maxPrice, bool? isValidPriceRange)
        {
            isValidPriceRange ??= minPrice <= maxPrice;
            return (bool)isValidPriceRange ? products.Where(p => p.Price >= minPrice && p.Price <= maxPrice) : products;
        }

        public static IEnumerable<Product> ToPaginatedList(this IEnumerable<Product> products, int? pageNumber, int? pageSize)
        {
            pageNumber ??= 1;
            pageSize ??= 10;
            return products.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize).ToList();
        }

        public static IEnumerable<Product> SortBy(this IEnumerable<Product> products, SortBy? sortBy)
        {
            if (sortBy is null)
            {
                return products;
            }
            return sortBy switch
            {
                global::SortBy.PriceAsc => products.OrderBy(p => p.Price).ToList(),
                global::SortBy.PriceDesc => products.OrderByDescending(p => p.Price).ToList(),
                global::SortBy.NameAsc => products.OrderBy(p => p.ProductName).ToList(),
                global::SortBy.NameDesc => products.OrderByDescending(p => p.ProductName).ToList(),
                global::SortBy.IdAsc => products.OrderBy(p => p.ProductId).ToList(),
                global::SortBy.IdDesc => products.OrderByDescending(p => p.ProductId).ToList(),
                _ => products,
            };
        }
    }
}
