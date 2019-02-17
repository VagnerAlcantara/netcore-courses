using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using uniciv.api.Models;
using uniciv.api.Repositories.Interfaces;

namespace uniciv.api.Controllers
{
    public class FundoCapitalController : Controller
    {
        private readonly IFundoCapitalRepository _repo;

        public FundoCapitalController(IFundoCapitalRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("v1/fundocapital")]
        public IActionResult ListarFundos()
        {
            return Ok(
                _repo.Listar()
                );
        }
        [HttpGet("v1/fundocapital/{id}")]
        public IActionResult ObterFundo(Guid id)
        {
            return Ok(_repo.Obter(id));
        }
        [HttpPost("v1/fundocapital")]
        public IActionResult AdicionarFundos([FromBody]FundoCapitalModel model)
        {
            _repo.Adicionar(model);
            return Ok();
        }
        [HttpPut("v1/fundocapital")]
        public IActionResult AlterarFundos([FromBody]FundoCapitalModel model)
        {
            var fundo = _repo.Obter(model.Id);

            if (fundo == null)
            {
                return NotFound();
            }
            fundo.Id = model.Id;
            fundo.DataResgate = model.DataResgate;
            fundo.Nome = model.Nome;
            fundo.ValorAtual = model.ValorAtual;
            fundo.ValorNecessario = model.ValorNecessario;

            _repo.Alterar(fundo);
            return Ok();
        }
        [HttpDelete("v1/fundocapital")]
        public IActionResult RemoverFundo( Guid id)
        {
            var  reg = _repo.Obter(id);
            
            if (reg == null)
            {
                return NotFound();
            }

            _repo.Remover(reg);
            return Ok();
        }
    }
}