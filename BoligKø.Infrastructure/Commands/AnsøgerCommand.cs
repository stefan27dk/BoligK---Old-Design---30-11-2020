using BoligKø.Domain.Model;
using BoligKø.Infrastructure.Commands.Interfaces;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.patterns;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoligKø.Infrastructure.Commands
{
    public class AnsøgerCommand : Repository<Ansøger>, IAnsøgerCommand
    {
        public AnsøgerCommand(BoligKøContext context) : base(context)
        {
        }


    }
}
