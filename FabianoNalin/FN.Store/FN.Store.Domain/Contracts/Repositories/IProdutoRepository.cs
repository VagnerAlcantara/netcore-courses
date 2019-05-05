using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GeyByNomeAsync(string nome);
        Task<IEnumerable<Produto>> GetAllWithCategoriaaAsync();

    }
}
