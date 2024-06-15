using API_de_Produtos.Enums;
using API_de_Produtos.Models;
using API_de_Produtos.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_de_Produtos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            List<Product> products = await _productRepository.GetAll(); 
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            Product product = await _productRepository.GetById(id);

            if (product == null)
            {
                return BadRequest("Produto não encontrado.");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add([FromBody] Product product)
        {
            Product result = await _productRepository.Add(product);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update([FromBody] Product product, int id)
        {
            Product result = await _productRepository.GetById(id);

            if (result == null)
            {
                return BadRequest("Produto não encontrado.");
            }

            product.Id = id;
            result = await _productRepository.Update(product);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteById(int id)
        {

            Product product = await _productRepository.GetById(id);

            if (product == null)
            {
                return BadRequest("Produto não encontrado.");               
            }

            bool deleted = await _productRepository.DeleteById(id);
            return Ok(deleted);
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            List<Product> products = await _productRepository.GetAll();
            var stats = products.GroupBy(p => p.Type).Select(g => new
            {
                Tipo = g.Key,
                Quantidade = g.Count(),
                MediaPrecoUnitario = g.Average(p => p.Price),
            })
            .ToList();

            return Ok(stats);
        }  
    }
}
