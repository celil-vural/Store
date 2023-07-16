using Entities.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Order : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public string CustomerId { get; set; } = string.Empty;

        public int? EmployeeId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        public decimal Freight { get; set; }

        public string? ShipName { get; set; }

        public string? ShipAddress { get; set; }

        public string? ShipCity { get; set; }

        public string? ShipRegion { get; set; }

        public string? ShipPostalCode { get; set; }

        public string? ShipCountry { get; set; }

        public bool Complete { get; set; } = false;

        public bool Shipped { get; set; } = false;

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        [ForeignKey("ShipVia")]
        public Shipper? Shipper { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
