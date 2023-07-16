using Entities.Contracts;

namespace Entities.Models
{
    public class Customer : IEntity
    {
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string? ContactName { get; set; } = string.Empty;
        public string? ContactTitle { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Region { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Fax { get; set; } = string.Empty;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
