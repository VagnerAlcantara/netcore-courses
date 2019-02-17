using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesCRUDRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FilmesCRUDRazor.Pages.Filmes {
    public class IndexModel : PageModel {
        private readonly FilmesCRUDRazor.Models.FilmeContext _context;

        public IndexModel (FilmesCRUDRazor.Models.FilmeContext context) {
            _context = context;
        }

        public IList<Filme> Filme { get; set; }
        public SelectList Generos;
        public string FilmePorGenero { get; set; }
        public async Task OnGetAsync (string buscaPorGeneroNome, string filmePorGenero) {

            #region| Lógica do input
            IQueryable<string> queryGenero = (from f in _context.Filme orderby f.Genero select f.Genero);
            IQueryable<Filme> filmes = (from f in _context.Filme select f);

            if (!string.IsNullOrEmpty (buscaPorGeneroNome)) {
                filmes = filmes.Where (x => x.Titulo.Contains (buscaPorGeneroNome));
            }
            #endregion

            #region| Lógica do select
            if (!String.IsNullOrEmpty (filmePorGenero)) {
                filmes = filmes.Where (b => b.Genero == filmePorGenero);
            }
            #endregion

            Filme = await filmes.ToListAsync ();
            Generos = new SelectList(await queryGenero.Distinct().ToListAsync());
        }
    }
}