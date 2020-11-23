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
        public async Task OpretAsync(AnsøgningDto ansøgning)
        {

        }
        public async Task EditAsync(AnsøgningDto ansøgning)
        {

        }
        public async Task SletAsync(AnsøgningDto ansøgning)
        {

        }
        public async Task<AnsøgningDto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<AnsøgningDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
