using API_de_Produtos.Models;

namespace API_de_Produtos.Repository
{
    public interface IProdutoRepository
    {
        public Task<ProdutoModel> Add(ProdutoModel produto);
        public Task<ProdutoModel> Update(ProdutoModel produto);
        public Task<List<ProdutoModel>> GetAll();
        public Task<ProdutoModel> GetById(int id);
        public Task<bool> Delete(int id);
        public List<ProdutoModel> GetProdutos();
    }
}
