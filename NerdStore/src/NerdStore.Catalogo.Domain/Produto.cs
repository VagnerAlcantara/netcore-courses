using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Produto(string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem, Guid categoriaId)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaId = categoriaId;
        }

        //Adhoc setters
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        //TODO: Continuar no minuto 19
        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }
        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }
        public void DebitarEstoque(int quantidade)
        {
            //Transformando o número em positivo, para exemplos que a quantidade chegue -2
            if (quantidade < 0) quantidade *= -1;

            QuantidadeEstoque -= quantidade;
        }
        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }
        public void Validar()
        {
            
        }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        //Apenas pra atender o ORM (EntityFramework)
        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
    }
}
