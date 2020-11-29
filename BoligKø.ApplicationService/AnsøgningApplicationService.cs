using AutoMapper;
using BoligKø.ApplicationService.Dto;
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
        public AnsøgningApplicationService(IMapper mapper, IAnsøgningCommand ansøgningCommand)
        {
            this._mapper = mapper;
            this._ansøgningCommand = ansøgningCommand;
        }
        public async Task OpretAsync(AnsøgningDto ansøgning)
        {
            var ansøgningToInsert = _mapper.Map<Ansøgning>(ansøgning);
            ansøgningToInsert.ValidateState();
            await _ansøgningCommand.CreateAsync(ansøgningToInsert);
        }
        public async Task EditAsync(AnsøgningDto ansøgning)
        {
            //Todo: Venter på karl laver ny metode til at få include(ansøger).theninclude(ansøgers ansøgninger)
            var storedAnsøgning = await _ansøgningCommand.GetByIdIncludingAsync(ansøgning.Id, o => o.Ansøger);
            storedAnsøgning.SetAktiv(ansøgning.Aktiv);
            storedAnsøgning.SetAnsøger(_mapper.Map<Ansøger>(ansøgning.Ansøger));
            storedAnsøgning.SetØvrigKommentar(ansøgning.ØvrigKommentar);
            storedAnsøgning.SetKriterier(_mapper.Map<IEnumerable<Kriterie>>(ansøgning.Kriterier));
            storedAnsøgning.ValidateState();
            storedAnsøgning.Ansøger.ValidateState();
            await _ansøgningCommand.UpdateAsync(storedAnsøgning);

        }
        public async Task SletAsync(string id)
        {
            var ansøgningToDelete = await _ansøgningCommand.GetByIdAsync(id);
            await _ansøgningCommand.DeleteAsync(ansøgningToDelete);
        }
    }
}
