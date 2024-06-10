using API_de_Produtos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_de_Produtos.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(250)");
            builder.Property(x => x.Tipo).HasColumnName("tipo").HasColumnType("varchar(250");
            builder.Property(x => x.PrecoUnitario).HasColumnName("preco_unitario").HasColumnType("float");
        }
    }
}
