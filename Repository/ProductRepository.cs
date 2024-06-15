using API_de_Produtos.Data;
using API_de_Produtos.Models;
using API_de_Produtos.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_de_Produtos.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDBContext _dbContext;

        public ProductRepository(ProductsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> Add(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            _dbContext.SaveChanges();

            return product;
        }

        public async Task<bool> DeleteById(int id)
        {
            Product product = await GetById(id);          

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<List<Product>> GetAll()
        {                   
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {            
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Product> Update(Product product)
        {
            Product result = await GetById(product.Id);
           
            result.Name = product.Name;
            result.Type = product.Type;
            result.Price = product.Price;

            await _dbContext.SaveChangesAsync();
            return result;
        }     
    }
}
