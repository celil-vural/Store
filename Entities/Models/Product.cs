using Entities.Contracts;

namespace Entities.Models;
public class Product : IEntity
{
    public int ProductId { get; init; }
    public String ProductName { get; set; } = String.Empty;
    public int SupplierId { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; init; }
    public string QuantityPerUnit { get; set; } = String.Empty;
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public short UnitsOnOrder { get; set; }
    public short ReorderLevel { get; set; }
}
