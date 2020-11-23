using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BoligKø.Infrastructure.Commands.Interfaces
{
    public interface IAnsøgningCommand
    {
        public Task<ICollection<Ansøgning>> GetAllAsync();
        public Task<ICollection<Ansøgning>> GetAllIncludingAsync([NotNullAttribute] Expression<Func<Ansøgning, object>> navigationPropertyPath);
        public Task<Ansøgning> GetByIdAsync(string id);
        public Task<Ansøgning> GetByIdIncludingAsync(string id, [NotNullAttribute] Expression<Func<Ansøgning, object>> navigationPropertyPath);
        public Task CreateAsync(Ansøgning ansøger);
        public Task UpdateAsync(Ansøgning ansøger);
        public Task DeleteAsync(Ansøgning ansøger);


    }
}
