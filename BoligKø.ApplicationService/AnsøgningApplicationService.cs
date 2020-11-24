using AutoMapper;
using BoligKø.ApplicationService.Dto;
using BoligKø.Domain.DomainService;
using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public class AnsøgningApplicationService : IAnsøgningApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IAnsøgningCommand _ansøgningCommand;
        private readonly IAnsøgerAnsøgningDomainService _ansøgerAnsøgningDomainService;

        public AnsøgningApplicationService(IMapper mapper, IAnsøgningCommand ansøgningCommand, IAnsøgerAnsøgningDomainService ansøgerAnsøgningDomainService)
        {
            this._mapper = mapper;
            this._ansøgningCommand = ansøgningCommand;
            this._ansøgerAnsøgningDomainService = ansøgerAnsøgningDomainService;
        }
        public async Task OpretAsync(AnsøgningDto ansøgning)
        {
            var ansøgningToInsert = _mapper.Map<Ansøgning>(ansøgning);

            foreach (var kriterie in ansøgning.Kriterier)
            {
                ansøgningToInsert.Addkriterie(_mapper.Map<IKriterie>(kriterie));
            }
            ansøgningToInsert.ValidateState();
            await _ansøgningCommand.CreateAsync(ansøgningToInsert);
        }
        public async Task EditAsync(AnsøgningDto ansøgning)
        {
            var storedAnsøgning = await _ansøgningCommand.GetByIdIncludingAsync(ansøgning.Id, o => o.Ansøger);
            storedAnsøgning.SetAktiv(ansøgning.Aktiv);
            storedAnsøgning.SetAnsøger(_mapper.Map<Ansøger>(ansøgning.Ansøger));
            storedAnsøgning.SetØvrigKommentar(ansøgning.ØvrigKommentar);
            await _ansøgerAnsøgningDomainService.UpdateAnsøgningAsync(storedAnsøgning.Ansøger, storedAnsøgning);
            storedAnsøgning.ValidateState();
            await _ansøgningCommand.UpdateAsync(storedAnsøgning);

        }
        public async Task SletAsync(string id)
        {
            var ansøgningToDelete = new Ansøgning();
            ansøgningToDelete.SetId(id);
            await _ansøgningCommand.DeleteAsync(ansøgningToDelete);
        }
    }
}
