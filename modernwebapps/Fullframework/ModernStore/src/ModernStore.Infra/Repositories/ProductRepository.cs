using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetProductListCommandResult> Get()
        {
            var query = @"SELECT 
	                            [Id], [Title], [Price], [Image], [QuantityOnHand]
                            FROM 
	                            [dbo].[Product]";

            using (var conn = new SqlConnection(@"Server=DESKTOP-VNQBMNU;Database=MordernStore;Trusted_Connection=True;"))
            {
                conn.Open();
                return conn.Query<GetProductListCommandResult>(query);
            }
        }
    }
}
