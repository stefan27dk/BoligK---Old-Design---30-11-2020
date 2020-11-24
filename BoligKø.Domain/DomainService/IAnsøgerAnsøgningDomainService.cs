using BoligKø.Domain.Model;
using System.Threading.Tasks;

namespace BoligKø.Domain.DomainService
{
    public interface IAnsøgerAnsøgningDomainService
    {
        Task UpdateAnsøgningAsync(Ansøger ansøger, Ansøgning ansøgning);
    }
}