using Entities.Contracts;

namespace Entities.Dtos.ShipperDto
{
    public class ShipperDto : IDto
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
