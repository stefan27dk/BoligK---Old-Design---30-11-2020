using BoligKø.ApplicationService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public interface IAnsøgningApplicationService
    {
        Task EditAsync(AnsøgningDto ansøgning);
        Task OpretAsync(AnsøgningDto ansøgning);
        Task SletAsync(AnsøgningDto ansøgning);
    }
}