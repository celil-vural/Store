using Entities.Contracts;

namespace Entities.Models
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string Audit { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
