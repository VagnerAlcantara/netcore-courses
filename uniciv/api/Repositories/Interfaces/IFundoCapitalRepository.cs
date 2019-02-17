using System;
using System.Collections.Generic;
using uniciv.api.Models;

namespace uniciv.api.Repositories.Interfaces
{
    public interface IFundoCapitalRepository
    {
        void Adicionar(FundoCapitalModel model);
        void Alterar(FundoCapitalModel model);
        void Remover(FundoCapitalModel model);
        IEnumerable<FundoCapitalModel> Listar();
        FundoCapitalModel Obter(Guid id);
    }
}