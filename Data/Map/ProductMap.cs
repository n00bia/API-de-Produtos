using API_de_Produtos.Enums;
using API_de_Produtos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_de_Produtos.Data.Map
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("nome").HasColumnType("varchar(250)");
            builder.Property(x => x.Type).HasColumnName("tipo").HasColumnType("int");
            builder.Property(x => x.Price).HasColumnName("preco_unitario").HasColumnType("float");
        }
    }
}
