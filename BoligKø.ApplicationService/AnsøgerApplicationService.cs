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
        public AnsøgerApplicationService()
        {

        }
        public async Task OpretAsync(AnsøgerDto ansøger)
        {
            var recordToInsert = new Ansøger();
        }
        public async Task EditAsync(AnsøgerDto ansøger)
        {

        }
        public async Task SletAsync(AnsøgerDto ansøger)
        {

        }
        private async Task<AnsøgerDto> GetAsync(string id)
        {
            throw new NotImplementedException();

        }
        private async Task<IEnumerable<AnsøgerDto>> GetAllAsync()
        {
            throw new NotImplementedException();

        }
    }
}
