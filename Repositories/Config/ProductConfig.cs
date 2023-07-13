using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.UnitsInStock).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.QuantityPerUnit).IsRequired();
            builder.Property(p => p.ReorderLevel).IsRequired();
            builder.Property(p => p.SupplierId).IsRequired();
            builder.Property(p => p.UnitsOnOrder).IsRequired();
        }
    }
}
