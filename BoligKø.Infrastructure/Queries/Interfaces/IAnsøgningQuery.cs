using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoligKø.Infrastructure.Queries.interfaces
{
    public interface IAnsøgningQuery
    {
        public IQueryable<Ansøgning> GetAll();
        public Ansøgning GetById(string id);
    }
}
