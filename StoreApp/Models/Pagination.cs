namespace StoreApp.Models
{
    public class Pagination
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage
        {
            get
            {
                decimal v = ((decimal)(TotalItems / ItemsPerPage));
                // return (int)v + ((TotalItems % ItemsPerPage) > 0 ? 1 : 0);
                return (int)Math.Ceiling(v);
            }
        }
    }
}
