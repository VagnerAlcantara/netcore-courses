using KissLog;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreIdentity.Controllers
{
    public class TesteController : Controller
    {
        private readonly ILogger _log;

        public TesteController(ILogger log)
        {
            _log = log;
        }
        public IActionResult Index()
        {
            _log.Trace("Ocorreu um erro");

            return View();
        }

        public IActionResult Erro()
        {
            throw new Exception("Erro forçado");

            return View();
        }
    }
}