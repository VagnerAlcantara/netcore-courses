using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NerdStore.Vendas.Domain
{
    public class Pedido : Entity, IAggregateRoot
    {
        public Pedido(Guid clienteId, bool voucherUtilizado, decimal desconto, decimal valorTotal)
        {
            ClienteId = clienteId;
            VoucherUtilizado = voucherUtilizado;
            Desconto = desconto;
            ValorTotal = valorTotal;
            _pedidoItems = new List<PedidoItem>();
        }
        protected Pedido()
        {
            _pedidoItems = new List<PedidoItem>();
        }
        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }
        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;
        //EF Relation
        public virtual Voucher Voucher { get; private set; }
        public void AdicionarItem(PedidoItem item)
        {
            if (!item.EhValido()) return;

            item.AssociarPedido(Id);
            if (PedidoItemExistente(item))
            {
                var itemExistente = _pedidoItems.FirstOrDefault(x => x.ProdutoId == item.ProdutoId);
                item.AdicionarUnidades(item.Quantidade);
                item = itemExistente;
                _pedidoItems.Remove(itemExistente);
            }
            item.CalcularValor();
            _pedidoItems.Add(item);

            CalcularValorPedido();
        }
        public void RemoverItem(PedidoItem item)
        {
            if (!item.EhValido()) return;

            var itemExistente = PedidoItems.FirstOrDefault(x => x.ProdutoId == item.ProdutoId);

            if (itemExistente == null) throw new DomainException("O item não pertence ao pedido");

            _pedidoItems.Remove(itemExistente);

            CalcularValorPedido();
        }
        public void AtualizarItem(PedidoItem item)
        {
            if (!item.EhValido()) return;

            item.AssociarPedido(Id);

            var itemExistente = PedidoItems.FirstOrDefault(x => x.ProdutoId == item.ProdutoId);

            if (itemExistente == null) throw new DomainException("O item não pertence ao pedido");

            _pedidoItems.Remove(itemExistente);

            _pedidoItems.Add(itemExistente);

            CalcularValorPedido();
        }
        public void AtualizarUnidades(PedidoItem item, int unidades)
        {
            item.AtualizarUnidades(unidades);

            AtualizarItem(item);
        }
        public void AplicarVoucher(Voucher voucher)
        {
            Voucher = voucher;
            VoucherUtilizado = true;
            CalcularValorPedido();
        }
        public void CalcularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(x => x.CalcularValor());
            CalcularValorTotalDesconto();
        }
        public void CalcularValorTotalDesconto()
        {
            if (!VoucherUtilizado) return;

            decimal desconto = 0;
            var valor = ValorTotal;
            if (Voucher.TipoDescontoVoucher == TipoDescontoVoucher.Porcentagem)
            {
                if (Voucher.Percentual.HasValue)
                {
                    desconto = (valor * Voucher.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Voucher.ValorDesconto.HasValue)
                {
                    desconto = Voucher.ValorDesconto.Value;
                    valor -= desconto;
                }
            }
            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }
        public bool PedidoItemExistente(PedidoItem pedidoItem)
        {
            return _pedidoItems.Any(x => x.ProdutoId == pedidoItem.ProdutoId);
        }
        public void TornarRascunho()
        {
            PedidoStatus = PedidoStatus.Rascunho;
        }
        public void IniciarPedido()
        {
            PedidoStatus = PedidoStatus.Iniciado;
        }
        public void FinalizarPedido()
        {
            PedidoStatus = PedidoStatus.Pago;
        }
        public void CancelarPedido()
        {
            PedidoStatus = PedidoStatus.Cancelado;
        }

        public static class PedidoFactory
        {
            public static Pedido NovoPedidoRascunho(Guid clienteId)
            {
                var pedido = new Pedido
                {
                    ClienteId = clienteId,
                };
                
                pedido.TornarRascunho();

                return pedido;
            }
        }
    }
}
