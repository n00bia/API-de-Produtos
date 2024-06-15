using API_de_Produtos.Models;

namespace API_de_Produtos.Repository.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> Add(Product product);
        public Task<Product> Update(Product product);
        public Task<List<Product>> GetAll();
        public Task<Product> GetById(int id);
        public Task<bool> DeleteById(int id);        
    }
}
