using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;

using System.Text;

namespace NerdStore.Core.Messages
{
    public abstract class Command : Message, IRequest<bool>
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
