using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Command.Results
{
    public class RegisterOrderCommandResult : ICommandResult
    {
        public RegisterOrderCommandResult(string number)
        {
            Number = number;
        }
        public string Number { get; set; }
    }
}
