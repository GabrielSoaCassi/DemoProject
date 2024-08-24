using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDemo.Domain.Entities;

namespace ProjetoDemo.Infra.Data.EntitiesConfiguration
{
    internal class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);

        }
    }
}
