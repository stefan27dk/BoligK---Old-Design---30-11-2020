using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.Patterns;
using BoligKø.Infrastructure.Queries.interfaces;

namespace BoligKø.Infrastructure.Queries
{
    public class AnsøgerQuery : Query<Ansøger> , IAnsøgerQuery
    {
        public AnsøgerQuery(BoligKøContext context) : base(context)
        {
        }
    }
}
