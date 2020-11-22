using BoligKø.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public interface IAnsøgerApplicationService
    {
        Task EditAnsøgerAsync(Ansøger ansøger);
        Task<IEnumerable<Ansøger>> GetAllAnsøgereAsync();
        Task<Ansøger> GetAnsøgerAsync(string id);
        Task OpretAnsøgerAsync(Ansøger ansøger);
        Task SletAnsøgerAsync(Ansøger ansøger);
    }
}