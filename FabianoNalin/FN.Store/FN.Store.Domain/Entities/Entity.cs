using System;
using System.Collections.Generic;
using System.Text;

namespace FN.Store.Domain.Entities
{
    public abstract class Entity
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
