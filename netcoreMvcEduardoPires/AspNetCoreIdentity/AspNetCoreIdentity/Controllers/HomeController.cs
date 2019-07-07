using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Extensions;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClaimGravar()
        {
            return View("Secret");
        }

        [ClaimsAutorizeAttribute("Produtos", "Ler")]
        public IActionResult ClaimsCustom()
        {
            return View("Secret");
        }

        //length(3,3): deve ter no mínimo 3 e no máximo 3 caracteres
        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();

            if (id == 500)
            {
                errorViewModel.Mensagem = "Ocorreu um erro. Tente novamente mais tarde ou contate nosso suporte.";
                errorViewModel.Titulo = "Ocorreu um erro!";
                errorViewModel.ErroCode = id;
            }
            else if (id == 404)
            {
                errorViewModel.Mensagem = "A página que está procurando não existe!<br/> Em caso de dúvidas entre em contato com nosso suporte";
                errorViewModel.Titulo = "Ops! Página não encontrada";
                errorViewModel.ErroCode = id;
            }
            else if (id == 403)
            {
                errorViewModel.Mensagem = "Você não tem permissão para fazer isto";
                errorViewModel.Titulo = "Acesso negado";
                errorViewModel.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }
            return View("Error", errorViewModel);
        }
    }
}
