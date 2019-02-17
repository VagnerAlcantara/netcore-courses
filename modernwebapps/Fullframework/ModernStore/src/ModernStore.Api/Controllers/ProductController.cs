using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Repositories;

namespace ModernStore.Api.Controllers
{
    //[Route("api")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/Products")]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }
        /*
        [HttpGet]
        [Route("v1/Products/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok($"Produto {id} ");
        }

        [HttpPost]
        [Route("v1/Products")]
        public IActionResult Post()
        {
            return Ok($"Criando um novo produto");
        }
        */
    }
}
