using System;
using System.Collections.Generic;
using System.Linq;
using uniciv.api.Models;
using uniciv.api.Repositories.Interfaces;

namespace uniciv.api.Repositories
{
    public class FundoCapitalRepository : IFundoCapitalRepository
    {
        private readonly List<FundoCapitalModel> _storage;

        public FundoCapitalRepository()
        {
            _storage = new List<FundoCapitalModel>();
        }

        public void Adicionar(FundoCapitalModel model)
        {
            _storage.Add(model);
        }

        public void Alterar(FundoCapitalModel model)
        {
            var index = _storage.FindIndex(0, 1, x => x.Id == model.Id);

            _storage[index] = model;
        }

        public IEnumerable<FundoCapitalModel> Listar()
        {
            return _storage;
        }

        public FundoCapitalModel Obter(Guid id)
        {
            return _storage.FirstOrDefault(x => x.Id == id);
        }

        public void Remover(FundoCapitalModel model)
        {
            _storage.Remove(model);
        }
    }
}