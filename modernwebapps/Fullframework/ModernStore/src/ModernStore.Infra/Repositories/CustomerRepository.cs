using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Customer Get(Guid id)
        {
            return _context.Customers
                .Include(x => x.User) // JOIN
                                      //.AsNoTracking() //Faz apenas select, sem proxy, sem sujeira -- Utilizado apenas para leitura.
                .FirstOrDefault(x => x.Id == id);// Colocar FirstOrDefault sempre após o where, where nunca fica por último

        }

        public Customer GetByUsername(string username)
        {
            return _context
                .Customers
                .Include(x => x.User)
                .FirstOrDefault(x => x.User.Username == username);
        }
        public GetCustomerCommandResult Get(string username)
        {
            /* Buscva com entityframework
            return _context
                .Customers
                .Include(x => x.User)
                .AsNoTracking()
                .Select(x => new GetCustomerCommandResult
                {
                    Name = x.Name.ToString(),
                    Document = x.Document.Number,
                    Active = x.Active,
                    Email = x.Email.Address,
                    Password = x.User.Password.Field,
                    Username = x.User.Username
                })
                .FirstOrDefault(x => x.Username == username);
            */
            //Dapper
            var query = "SELECT* FROM[GETCUSTOMERINFOVIEW] WHERE [ACTIVE] = 1 AND [USERNAME] == @USERNAME";

            using (var conn = new SqlConnection(@"Server=DESKTOP-VNQBMNU;Database=MordernStore;Trusted_Connection=True;"))
            {
                conn.Open();
                return conn.Query<GetCustomerCommandResult>(query, new
                {
                    username = new DbString
                    {
                        Value = username,
                        IsFixedLength = false,
                        Length = 20,
                        IsAnsi = true
                    }
                }).FirstOrDefault();
            }
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            //_context.SaveChanges(); não usar, pois aqui finaliza a transação, não é esse momento
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        
    }
}
