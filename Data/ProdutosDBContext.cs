using API_de_Produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_de_Produtos.Data
{
    public class ProdutosDBContext : DbContext
    {
        public ProdutosDBContext(DbContextOptions<ProdutosDBContext> options, IConfiguration configuration)
           : base(options)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("String"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var produto = modelBuilder.Entity<ProdutoModel>();

            produto.ToTable("produto");
            produto.HasKey(x => x.Id);
            produto.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            produto.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(250)");
            produto.Property(x => x.Tipo).HasColumnName("tipo").HasColumnType("varchar(250");
            produto.Property(x => x.PrecoUnitario).HasColumnName("preco_unitario").HasColumnType("float");

        }
    }
}
