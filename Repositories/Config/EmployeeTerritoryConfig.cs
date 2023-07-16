using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class EmployeeTerritoryConfig : IEntityTypeConfiguration<EmployeeTerritory>
    {
        public void Configure(EntityTypeBuilder<EmployeeTerritory> builder)
        {
            builder.HasNoKey();
        }
    }
}
