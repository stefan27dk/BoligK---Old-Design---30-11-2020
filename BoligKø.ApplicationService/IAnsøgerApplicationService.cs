using BoligKø.ApplicationService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public interface IAnsøgerApplicationService
    {
        Task EditAnsøgerAsync(AnsøgerDto ansøger);
        Task OpretAnsøgerAsync(AnsøgerDto ansøger);
        Task SletAnsøgerAsync(string id);
    }
}