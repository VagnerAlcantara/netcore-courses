using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repositories
{
    public abstract class RepositoryEF<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly StoreDataContext _context;
        protected readonly DbSet<TEntity> _db;

        public RepositoryEF(StoreDataContext context)
        {
            _context = context;
            _db = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(object id)
        {
            return await _db.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _db.ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _db.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            _db.Remove(entity);
            _context.SaveChanges();
        }

    }
}
