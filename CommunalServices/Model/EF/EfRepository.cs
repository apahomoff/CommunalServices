using CommunalServices.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections;

namespace CommunalServices.Model.EF
{
    /// <summary>
    /// Хранилище данных реализованное через Entity Framework.
    /// </summary>
    public class EFRepository : IRepository
    {
        private AppDbContext db;

        public EFRepository(AppDbContext db) => this.db = db;

        public async Task CreateAsync<TEntity>(TEntity entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync<TEntity>(int id) where TEntity : class
        {
            return await db.FindAsync<TEntity>(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public async Task EditAsync<TEntity>(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task RemoveAsync<TEntity>(TEntity entity)
        {
            db.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync<TEntity>(
            Expression<Func<TEntity, bool>> predicate, 
            IEnumerable<Expression<Func<TEntity, Object>>> includes) 
            where TEntity : class
        {
            if (includes == null || !includes.Any())
            {
                throw new ArgumentNullException(nameof(includes));
            }

            IIncludableQueryable<TEntity, Object> includableQueryable = null;

            foreach (var include in includes)
            {
                includableQueryable = includableQueryable == null ? 
                    db.Set<TEntity>().Include(include) : includableQueryable.Include(include);
            }

            return await includableQueryable.FirstOrDefaultAsync(predicate);
        }
    }
}
