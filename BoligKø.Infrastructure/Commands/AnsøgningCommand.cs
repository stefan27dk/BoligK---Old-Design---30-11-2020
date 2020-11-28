using BoligKø.ApplicationService;
using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.Exceptions;
using BoligKø.Infrastructure.patterns;
using System.Linq;
using System.Threading.Tasks;

namespace BoligKø.Infrastructure.Commands
{
    public class AnsøgningCommand : Repository<Ansøgning>, IAnsøgningCommand
    {
        public AnsøgningCommand(BoligKøContext context) : base(context)
        {
        }

        protected override void HandleEntityBeforeDataChangeOperation(Ansøgning entity)
        { 
            var trackedAnsøger = context.Ansøgere.FirstOrDefault(a => a.Id == entity.Ansøger.Id);
            if (trackedAnsøger == null)
                throw new NoValidNavigationEntityFoundException("Ansøgningens ansøger findes ikke i databasen"); 
            entity.SetAnsøger(trackedAnsøger);
        }

    }
}
