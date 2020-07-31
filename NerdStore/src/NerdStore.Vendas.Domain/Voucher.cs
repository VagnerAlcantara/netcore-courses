using NerdStore.Core.DomainObjects;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NerdStore.Vendas.Domain
{
    public class Voucher : Entity
    {
        public string Codigo { get; private set; }
        public decimal? Percentual { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public TipoDescontoVoucher TipoDescontoVoucher { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }

        //EF Relation
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
