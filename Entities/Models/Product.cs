using Entities.Contracts;

namespace Entities.Models;
public class Product : IEntity
{
    public int ProductId { get; set; }
    public String ProductName { get; set; } = String.Empty;
    public int SupplierId { get; set; }
    public int CategoryId { get; set; }
    public string QuantityPerUnit { get; set; } = String.Empty;
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public short UnitsOnOrder { get; set; }
    public short ReorderLevel { get; set; }
}
