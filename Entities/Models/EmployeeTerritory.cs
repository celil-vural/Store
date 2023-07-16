using Entities.Contracts;

namespace Entities.Models
{
    public class EmployeeTerritory : IEntity
    {
        public int EmployeeId { get; set; }
        public int TerritoryId { get; set; }
    }
}
