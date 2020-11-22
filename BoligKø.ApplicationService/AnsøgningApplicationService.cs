using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public class AnsøgningApplicationService : IAnsøgningApplicationService
    {
        public async Task OpretAnsøgningAsync(Ansøgning ansøgning)
        {

        }
        public async Task EditAnsøgningAsync(Ansøgning ansøgning)
        {

        }
        public async Task SletAnsøgningAsync(Ansøgning ansøgning)
        {

        }
        public async Task<Ansøgning> GetAnsøgningAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Ansøgning>> GetAllAnsøgningerAsync()
        {
            throw new NotImplementedException();
        }
    }
}
