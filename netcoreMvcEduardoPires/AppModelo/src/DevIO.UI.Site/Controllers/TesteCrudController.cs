using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.UI.Site.Data;
using DevIO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _context;

        public TesteCrudController(MeuDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Aluno aluno = new Aluno
            {
                Nome = "Vagner",
                DataNascimento = DateTime.Now,
                Email = "vagneralcantara15@gmail.com"
            };

            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            var aluno2 = _context.Alunos.Find(aluno.Id);

            var aluno3 = _context.Alunos.FirstOrDefault(x => x.Email == "vagneralcantara15@gmail.com");

            aluno.Nome = "João";

            _context.Alunos.Update(aluno);
            _context.SaveChanges();

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();


            return View("_Layout");
        }
    }
}