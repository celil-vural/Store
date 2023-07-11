using Entities.Contracts;

namespace Entities.Models;
public class Category : IEntity
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public byte[] Picture { get; set; }
}
