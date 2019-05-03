using FN.Store.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FN.Store.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _produtoRepository.GetAsync();

            return Ok(data);
        }
    }
}