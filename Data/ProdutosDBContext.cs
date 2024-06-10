using API_de_Produtos.Data.Map;
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
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
