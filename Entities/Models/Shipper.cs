using Entities.Contracts;

namespace Entities.Models
{
    public class Shipper : IEntity
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
