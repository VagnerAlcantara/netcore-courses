using FN.Store.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FN.Store.Api.Models
{
    public class ProdutosGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }
    public class ProdutoAddEdit
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(100, ErrorMessage ="Limite de carácteres excedido")]
        public string Nome { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage ="Valor inválido")]
        public decimal Preco { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
    public static class ProdutoModelExtension
    {
        public static ProdutosGet ToProdutoGet(this Produto produto)
        {
            return new ProdutosGet
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                CategoriaId = produto.CategoriaId,
                CategoriaNome = produto.Categoria?.Nome
            };
        }
        public static Produto ToProduto(this ProdutoAddEdit model)
        {
            return new Produto
            {
                Nome = model.Nome,
                Preco = model.Preco,
                CategoriaId = model.CategoriaId
            };
        }
    }
}
