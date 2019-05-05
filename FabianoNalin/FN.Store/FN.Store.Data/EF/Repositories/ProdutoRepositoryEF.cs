using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repositories
{
    public class ProdutoRepositoryEF : RepositoryEF<Produto>, IProdutoRepository
    {
        public ProdutoRepositoryEF(StoreDataContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Produto>> GetAllWithCategoriaaAsync()
        {
            return await _db.Include(x => x.Categoria).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GeyByNomeAsync(string nome)
        {
            return await _db.Where(x => x.Nome.Contains(nome)).ToListAsync();
        }
    }
}
