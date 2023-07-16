using Entities.Models;

namespace Entities.Dtos.OrderDtos
{
    public class OrderDtoForInsertion
    {
        public int OrderId { get; init; }
        public DateTime? OrderDate { get; init; } = DateTime.Now;
        public DateTime? RequiredDate { get; init; } = DateTime.Now.AddDays(10);
        public int? ShipVia { get; init; }
        public decimal? Freight { get; init; }
        public string? ShipName { get; init; } = string.Empty;
        public string? ShipAddress { get; init; } = string.Empty;
        public string? ShipCity { get; init; } = string.Empty;
        public string? ShipRegion { get; init; } = string.Empty;
        public string? ShipPostalCode { get; init; } = string.Empty;
        public string? ShipCountry { get; init; } = string.Empty;
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
