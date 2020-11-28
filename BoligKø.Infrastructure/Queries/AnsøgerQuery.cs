using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.Patterns;
using BoligKø.Infrastructure.Queries.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BoligKø.Infrastructure.Queries
{
    public class AnsøgerQuery : Query<Ansøger> , IAnsøgerQuery
    {
        public AnsøgerQuery(BoligKøContext context) : base(context)
        {
        }

        /// <summary>
        /// Returns matching Ansøger. If no match found returns null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Ansøger GetByuserId(string id)
        {
            var all = GetAll();
            return all.FirstOrDefault(a => a.UserId == id);
        }

        public Ansøger GetByUserIdIncluding(string id, [NotNull] Expression<Func<Ansøger, object>> navigationPropertyPath)
        {
            return context.Ansøgere
                .Include(navigationPropertyPath)
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
