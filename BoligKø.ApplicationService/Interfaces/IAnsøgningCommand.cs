using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public interface IAnsøgningCommand
    {
        public Task<ICollection<Ansøgning>> GetAllAsync();
        public Task<ICollection<Ansøgning>> GetAllIncludingAsync([NotNullAttribute] Expression<Func<Ansøgning, object>> navigationPropertyPath);
        public Task<Ansøgning> GetByIdAsync(string id);
        public Task<Ansøgning> GetByIdIncludingAsync(string id, [NotNullAttribute] Expression<Func<Ansøgning, object>> navigationPropertyPath);
        public Task CreateAsync(Ansøgning ansøgning);
        public Task UpdateAsync(Ansøgning ansøgning);
        public Task DeleteAsync(Ansøgning ansøgning);


    }
}
