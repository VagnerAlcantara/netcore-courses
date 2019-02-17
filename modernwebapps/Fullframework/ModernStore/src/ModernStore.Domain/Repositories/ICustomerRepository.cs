using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByUsername(string username);
        GetCustomerCommandResult Get(string username);
        void Update(Customer customer);
        void Save(Customer customer);
        bool DocumentExists(string document);

    }
}
