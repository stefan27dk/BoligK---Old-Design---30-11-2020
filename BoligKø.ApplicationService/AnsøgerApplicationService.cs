using BoligKø.ApplicationService.Dto;
using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public class AnsøgerApplicationService : IAnsøgerApplicationService
    {
        public async Task OpretAnsøgerAsync(AnsøgerDto ansøger)
        {

        }
        public async Task EditAnsøgerAsync(AnsøgerDto ansøger)
        {

        }
        public async Task SletAnsøgerAsync(AnsøgerDto ansøger)
        {

        }
        public async Task<AnsøgerDto> GetAnsøgerAsync(string id)
        {
            throw new NotImplementedException();

        }
        public async Task<IEnumerable<AnsøgerDto>> GetAllAnsøgereAsync()
        {
            throw new NotImplementedException();

        }
    }
}
