using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService
    {
    }
    public interface IEstoqueService
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        Task<bool> ReporEstoque(Guid produtoId, int quantidade);
    }
}
