using System;

namespace uniciv.api.Models
{
    public class FundoCapitalModel
    {
        public FundoCapitalModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorNecessario { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime? DataResgate { get; set; }
    }
}