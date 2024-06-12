using API_de_Produtos.Data;
using API_de_Produtos.Models;
using API_de_Produtos.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_de_Produtos.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutosDBContext _dbContext;

        public ProdutoRepository(ProdutosDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProdutoModel> Add(ProdutoModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            _dbContext.SaveChanges();

            return produto;
        }

        public async Task<bool> Delete(int id)
        {
            ProdutoModel produtoById = await GetById(id);

            if (produtoById == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            _dbContext.Produtos.Remove(produtoById);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<List<ProdutoModel>> GetAll()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<ProdutoModel> GetById(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<ProdutoModel> Update(ProdutoModel produto)
        {
            ProdutoModel produtoAlvo =  _dbContext.Produtos.FirstOrDefault(p => p.Id == produto.Id);

            if(produtoAlvo == null)
            {
                throw new Exception("Produto não encontrado");
            }

            produtoAlvo.Nome = produto.Nome;
            produtoAlvo.Tipo = produto.Tipo;
            produtoAlvo.PrecoUnitario = produto.PrecoUnitario;

            _dbContext.Produtos.Update(produtoAlvo);
            _dbContext.SaveChanges();
            return Task.FromResult(produtoAlvo);
        }

        public List<ProdutoModel> GetProdutos()
        {
            return  _dbContext.Produtos.ToList();
        }
    }
}
