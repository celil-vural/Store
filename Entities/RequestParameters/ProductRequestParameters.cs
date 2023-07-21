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
        public SortBy SortBy { get; set; } = SortBy.IdAsc;
        public ProductRequestParameters() : this(1, 10) { }
        public ProductRequestParameters(int pageNumber = 1, int pageSize = 10)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public bool IsAuthorizedToSortById(string sortBy, List<string> userRoles)
        {
            // Eğer kullanıcı admin veya editor rolündeyse ve sortBy "IdDesc" veya "IdAsc" ise true döner
            return (userRoles.Contains("Admin") || userRoles.Contains("Editor")) && (sortBy == "IdDesc" || sortBy == "IdAsc");
        }
    }
}
public enum SortBy
{
    IdAsc,
    IdDesc,
    NameAsc,
    NameDesc,
    PriceAsc,
    PriceDesc
}