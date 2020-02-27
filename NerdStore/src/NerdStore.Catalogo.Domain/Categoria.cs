using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public string Nome { get; set; }
        public int Codigo { get; set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }
    }
}
