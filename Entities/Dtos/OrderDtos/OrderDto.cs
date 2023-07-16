using Entities.Contracts;

namespace Entities.Dtos.OrderDtos
{
    public record OrderDto : IDto
    {
        public int OrderId { get; init; }
        public string? CustomerId { get; init; } = string.Empty;
        public int? EmployeeId { get; init; }
        public DateTime? OrderDate { get; init; } = DateTime.Now;
        public DateTime? RequiredDate { get; init; } = DateTime.Now;
        public DateTime? ShippedDate { get; init; } = DateTime.Now;
        public int? ShipVia { get; init; }
        public decimal? Freight { get; init; }
        public string? ShipName { get; init; } = string.Empty;
        public string? ShipAddress { get; init; } = string.Empty;
        public string? ShipCity { get; init; } = string.Empty;
        public string? ShipRegion { get; init; } = string.Empty;
        public string? ShipPostalCode { get; init; } = string.Empty;
        public string? ShipCountry { get; init; } = string.Empty;
        public bool Shipped { get; init; }
        public bool Complete { get; init; }
    }
}
