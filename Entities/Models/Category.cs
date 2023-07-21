using Entities.Contracts;

namespace Entities.Models;
public class Category : IEntity
{
    public int CategoryId { get; set; }
    public String? CategoryName { get; set; } = String.Empty;

}
