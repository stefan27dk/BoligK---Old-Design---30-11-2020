using BoligKø.ApplicationService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public interface IAnsøgerApplicationService
    {
        Task EditAsync(AnsøgerDto ansøger);
        Task OpretAsync(AnsøgerDto ansøger);
        Task SletAsync(AnsøgerDto ansøger);
    }
}