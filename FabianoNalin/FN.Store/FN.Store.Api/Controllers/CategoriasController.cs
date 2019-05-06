using FN.Store.Api.Models;
using FN.Store.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FN.Store.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = (await _categoriaRepository.GetAsync()).Select(x => x.ToCategoriaGet());

            return Ok(data);
        }

        [HttpGet("{id}", Name = "CategoriaById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = (await _categoriaRepository.GetAsync(id))?.ToCategoriaGet();

            if (data == null) return NotFound();

            return Ok(data);
        }

        [HttpPost()]
        public IActionResult Add([FromBody] CategoriaAddEdit model)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = model.ToCategoria();

            _categoriaRepository.Add(data);

            return CreatedAtRoute("CategoriaById", new { id = data.Id }, data.ToCategoriaGet());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriaAddEdit model)
        {
            var categoria = await _categoriaRepository.GetAsync(id);

            if (categoria == null) ModelState.AddModelError("Id", "Categoria não encontrada");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            categoria.Update(model.Nome, model.Descricao);

            _categoriaRepository.Update(categoria);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaRepository.GetAsync(id);

            if (categoria == null) ModelState.AddModelError("Id", "Categoria não encontrada");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _categoriaRepository.Delete(categoria);

            return Ok();
        }
    }
}