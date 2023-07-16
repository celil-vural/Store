using Entities.Contracts;

namespace Entities.Models
{
    public class Territory : IEntity
    {
        public int TerritoryId { get; set; }
        public string TerritoryDescription { get; set; } = string.Empty;
        public int RegionId { get; set; }
    }
}
