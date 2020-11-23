using BoligKø.Domain.Model;
using BoligKø.Infrastructure.Commands.Interfaces;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.patterns;

namespace BoligKø.Infrastructure.Commands
{
    public class AnsøgningCommand : Repository<Ansøgning>, IAnsøgningCommand
    {
        public AnsøgningCommand(BoligKøContext context) : base(context)
        {
        }
    }
}
