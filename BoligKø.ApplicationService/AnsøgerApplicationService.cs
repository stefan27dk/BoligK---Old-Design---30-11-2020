using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public class AnsøgerApplicationService : IAnsøgerApplicationService
    {
        public async Task OpretAnsøgerAsync(Ansøger ansøger)
        {

        }
        public async Task EditAnsøgerAsync(Ansøger ansøger)
        {

        }
        public async Task SletAnsøgerAsync(Ansøger ansøger)
        {

        }
        public async Task<Ansøger> GetAnsøgerAsync(string id)
        {
            throw new NotImplementedException();

        }
        public async Task<IEnumerable<Ansøger>> GetAllAnsøgereAsync()
        {
            throw new NotImplementedException();

        }
    }
}
