using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.Patterns;
using BoligKø.Infrastructure.Queries.interfaces;
using System.Linq;
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
    }
}
