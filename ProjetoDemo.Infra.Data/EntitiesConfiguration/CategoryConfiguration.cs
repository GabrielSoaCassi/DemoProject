using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDemo.Domain.Entities;

namespace ProjetoDemo.Infra.Data.EntitiesConfiguration
{
    internal class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletrônicos"),
                new Category(3, "Acessórios")
                );
        }
    }
}
