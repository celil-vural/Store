namespace Entities.RequestParameters
{
    public class ProductRequestParameters : RequestParameters
    {
        public int? CategoryId { get; set; }
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = decimal.MaxValue;
        public bool IsValidPriceRange => MaxPrice > MinPrice;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; } = "PriceAsc";
        public ProductRequestParameters() : this(1, 10) { }
        public ProductRequestParameters(int pageNumber = 1, int pageSize = 10)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
