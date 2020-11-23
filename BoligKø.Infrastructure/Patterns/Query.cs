using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoligKø.Infrastructure.Patterns
{
    public class Query<T> where T : BaseEntity
    {
        private readonly BoligKøContext context;
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
    }
}
