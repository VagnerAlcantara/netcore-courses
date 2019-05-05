using FN.Store.Domain.Entities;

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
    }
}
