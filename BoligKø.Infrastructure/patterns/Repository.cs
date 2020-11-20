using BoligKø.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.Infrastructure.patterns
{
    public class Repository<T> where T : BaseEntity
    {
        private readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        /// <summary>
        /// Returns the entity by id. 
        /// If no matching entity found, returns null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(string id)
        {
            var dbSet = context.Set<T>();
            return await dbSet.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task CreateAsync(T entity)
        {
            var dbSet = context.Set<T>();
            dbSet.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var dbSet = context.Set<T>();
            var toUpdate = dbSet.Find(entity);
            toUpdate = entity;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var dbSet = context.Set<T>();
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
