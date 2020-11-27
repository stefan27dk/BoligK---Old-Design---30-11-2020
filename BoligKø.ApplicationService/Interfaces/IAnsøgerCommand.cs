using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{ 
    public interface IAnsøgerCommand
    {
        public Task<ICollection<Ansøger>> GetAllAsync();
        public Task<ICollection<Ansøger>> GetAllIncludingAsync([NotNullAttribute] Expression<Func<Ansøger, object>> navigationPropertyPath);
        public Task<Ansøger> GetByIdAsync(string id);
        public Task<Ansøger> GetByIdIncludingAsync(string id, [NotNullAttribute] Expression<Func<Ansøger, object>> navigationPropertyPath);
        public Task CreateAsync(Ansøger ansøger);
        public Task UpdateAsync(Ansøger ansøger);
        public Task DeleteAsync(Ansøger ansøger);
        
    }
}
