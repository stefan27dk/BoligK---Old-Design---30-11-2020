using BoligKø.ApplicationService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public interface IAnsøgningApplicationService
    {
        Task EditAnsøgningAsync(AnsøgningDto ansøgning);
        Task<IEnumerable<AnsøgningDto>> GetAllAnsøgningerAsync();
        Task<AnsøgningDto> GetAnsøgningAsync(string id);
        Task OpretAnsøgningAsync(AnsøgningDto ansøgning);
        Task SletAnsøgningAsync(AnsøgningDto ansøgning);
    }
}