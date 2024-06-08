using API_de_Produtos.Models;
using API_de_Produtos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_de_Produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> GetAll()
        {
            List<ProdutoModel> produtoList = await _produtoRepository.GetAll();
            return Ok(produtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetById(int id)
        {
            ProdutoModel produto = await _produtoRepository.GetById(id);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Add([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtoRepository.Add(produtoModel);
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Update([FromBody] ProdutoModel produtoModel, int id)
        {
            produtoModel.Id = id;
            ProdutoModel produto = await _produtoRepository.Update(produtoModel);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Delete(int id)
        {
            bool deleted = await _produtoRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
