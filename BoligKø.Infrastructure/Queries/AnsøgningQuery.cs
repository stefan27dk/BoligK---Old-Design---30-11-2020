using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.Patterns;
using BoligKø.Infrastructure.Queries.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BoligKø.Infrastructure.Queries
{
    public class AnsøgningQuery : Query<Ansøgning>, IAnsøgningQuery
    {
        public AnsøgningQuery(BoligKøContext context) : base(context)
        {
        }

        public List<Ansøgning> GetByAnsøgerId(string id)
        {
            return context.Ansøgninger
                .AsNoTracking()
                .Where(a => a.Ansøger.Id == id)
                .ToList();
        }
    }
}
