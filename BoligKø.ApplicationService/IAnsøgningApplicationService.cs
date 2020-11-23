using BoligKø.ApplicationService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public interface IAnsøgningApplicationService
    {
        Task EditAnsøgningAsync(AnsøgningDto ansøgning);
        Task OpretAnsøgningAsync(AnsøgningDto ansøgning);
        Task SletAnsøgningAsync(string id);
    }
}