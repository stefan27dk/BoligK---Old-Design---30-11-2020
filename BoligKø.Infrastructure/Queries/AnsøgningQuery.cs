using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.Patterns;
using BoligKø.Infrastructure.Queries.interfaces;

namespace BoligKø.Infrastructure.Queries
{
    public class AnsøgningQuery : Query<Ansøgning>, IAnsøgningQuery
    {
        public AnsøgningQuery(BoligKøContext context) : base(context)
        {
        }
    }
}
