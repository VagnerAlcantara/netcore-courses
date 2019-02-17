using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Results
{
    public class GetProductListCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public string QuantityOnHand { get; set; }
    }
}
