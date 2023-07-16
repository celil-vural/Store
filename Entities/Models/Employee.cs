using Entities.Contracts;

namespace Entities.Models
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Title { get; set; } = string.Empty;
        public string? TitleOfCourtesy { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Region { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? HomePhone { get; set; } = string.Empty;
        public string? Extension { get; set; } = string.Empty;
        public byte[] Photo { get; set; } = Array.Empty<byte>();
        public string? Notes { get; set; } = string.Empty;
        public int? ReportsTo { get; set; }
        public string? PhotoPath { get; set; } = string.Empty;
    }
}
