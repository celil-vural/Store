using Entities.Contracts;

namespace Entities.Models
{
    public class Region : IEntity
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; } = string.Empty;
    }
}
