using BoligKø.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public interface IAnsøgningApplicationService
    {
        Task EditAnsøgningAsync(Ansøgning ansøgning);
        Task<IEnumerable<Ansøgning>> GetAllAnsøgningerAsync();
        Task<Ansøgning> GetAnsøgningAsync(string id);
        Task OpretAnsøgningAsync(Ansøgning ansøgning);
        Task SletAnsøgningAsync(Ansøgning ansøgning);
    }
}