using BoligKø.ApplicationService.Dto;
using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public class AnsøgningApplicationService : IAnsøgningApplicationService
    {
        public async Task OpretAnsøgningAsync(AnsøgningDto ansøgning)
        {

        }
        public async Task EditAnsøgningAsync(AnsøgningDto ansøgning)
        {

        }
        public async Task SletAnsøgningAsync(AnsøgningDto ansøgning)
        {

        }
        public async Task<AnsøgningDto> GetAnsøgningAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<AnsøgningDto>> GetAllAnsøgningerAsync()
        {
            throw new NotImplementedException();
        }
    }
}
