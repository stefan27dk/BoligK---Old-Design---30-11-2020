using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BoligKø.Infrastructure.patterns
{
    public class Repository<T> where T : BaseEntity
    {
        protected readonly BoligKøContext context;
        public Repository(BoligKøContext context)
        {
            this.context = context;
        }

        protected virtual void HandleEntityBeforeDataChangeOperation(T entity)
        {

        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<ICollection<T>> GetAllIncludingAsync([NotNullAttribute] Expression<Func<T, object>> navigationPropertyPath)
        {
            return await context.Set<T>().Include(navigationPropertyPath).ToListAsync();
        }

        /// <summary>
        /// Returns the entity matching the id. 
        /// If no matching entity found, returns null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(string id)
        {
            var dbSet = context.Set<T>();
            return await dbSet.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<T> GetByIdIncludingAsync(string id, [NotNullAttribute] Expression<Func<T, object>> navigationPropertyPath)
        {
            var dbSet = context.Set<T>().Include(navigationPropertyPath);
            return await dbSet.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task CreateAsync(T entity)
        {
            HandleEntityBeforeDataChangeOperation(entity);
            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            HandleEntityBeforeDataChangeOperation(entity);
            var toUpdate = await context.Set<T>().FirstOrDefaultAsync(t => t.Id == entity.Id);
            toUpdate = entity;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            HandleEntityBeforeDataChangeOperation(entity);
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
