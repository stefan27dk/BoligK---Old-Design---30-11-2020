using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoligKø.Infrastructure.Queries.interfaces
{
    public interface IAnsøgerQuery
    {
        public IQueryable<Ansøger> GetAll();
        public Ansøger GetById(string id);
    }
}
