using DevIO.UI.Site.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        private IPedidoRepository _pedidoRepository;

        public HomeController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        //Quando não for possível utlizar construtor, porém o indicado é sempre passar no construtor
        //public IActionResult Index([FromServices] IPedidoRepository _pedidoRepository)
        //{

            //var pedido = _pedidoRepository.ObterPedido();

            //return View();
        //}

        public IActionResult Index()
        {

            var pedido = _pedidoRepository.ObterPedido();

            return View();  
        }
    }
}
