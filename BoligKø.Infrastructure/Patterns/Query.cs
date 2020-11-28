using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BoligKø.Infrastructure.Patterns
{
    public class Query<T> where T : BaseEntity
    {
        protected readonly BoligKøContext context;
        public Query(BoligKøContext context)
        {
            this.context = context;
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>().AsNoTracking();
        }

        public T GetById(string id)
        {
            return context.Set<T>().AsNoTracking()
                .FirstOrDefault(t => t.Id == id);
        }

        public T GetByIdIncluding(string id, [NotNull] Expression<Func<T, object>> navigationPropertyPath)
        {
            return context.Set<T>()
                .Include(navigationPropertyPath)
                .AsNoTracking()
                .FirstOrDefault(t => t.Id == id);
        }
    }
}
