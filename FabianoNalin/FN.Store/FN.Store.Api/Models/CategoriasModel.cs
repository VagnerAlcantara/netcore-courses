using FN.Store.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FN.Store.Api.Models
{
    public class CategoriasGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class CategoriaAddEdit
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Limite de carácteres excedido")]
        public string Nome { get; set; }

        [StringLength(300, ErrorMessage = "Limite de carácteres excedido")]
        public string Descricao { get; set; }
    }

    public static class CategoriasModelExtensions
    {
        public static CategoriasGet ToCategoriaGet(this Categoria categoria)
        {
            return new CategoriasGet
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Descricao = categoria.Descricao
            };
        }

        public static Categoria ToCategoria(this CategoriaAddEdit model)
        {
            return new Categoria
            {
                Nome = model.Nome,
                Descricao = model.Descricao
            };
        }
    }

}
