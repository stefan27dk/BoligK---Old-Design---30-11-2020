using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.Domain.DomainService
{
    public class AnsøgerAnsøgningDomainService : IAnsøgerAnsøgningDomainService
    {
        private Task SætAnsøgningAktivAsync(Ansøger ansøger, Ansøgning ansøgning)
        {
            var aktiveAnsøgninger = ansøger.Ansøgninger.Where(x => x.Aktiv == true);
            if (aktiveAnsøgninger.Count() > 1)
                throw new StateException("Kun 1 aktiv ansøgning");
            ansøgning.SetAktiv(true);
            return Task.CompletedTask;

        }
        public async Task UpdateAnsøgningAsync(Ansøger ansøger, Ansøgning ansøgning)
        {
            if (ansøgning.Aktiv)
                await SætAnsøgningAktivAsync(ansøger, ansøgning);
            ansøgning.ValidateState();
        }
    }
}
