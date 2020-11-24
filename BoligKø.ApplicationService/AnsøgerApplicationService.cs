using AutoMapper;
using BoligKø.ApplicationService.Dto;
using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.ApplicationService
{
    public class AnsøgerApplicationService : IAnsøgerApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IAnsøgerCommand _ansøgerCommand;

        public AnsøgerApplicationService(IMapper mapper, IAnsøgerCommand ansøgerCommand)
        {
            this._mapper = mapper;
            this._ansøgerCommand = ansøgerCommand;
        }
        public async Task OpretAsync(AnsøgerDto ansøger)
        {
            var recordToInsert = new Ansøger();
            foreach(var a in ansøger.Ansøgninger)
            {
                var ansøgningToInsert = _mapper.Map<Ansøgning>(a);

                foreach(var kriterie in a.Kriterier)
                {
                    ansøgningToInsert.Addkriterie(_mapper.Map<IKriterie>(kriterie));
                }
                recordToInsert.AddAnsøgning(ansøgningToInsert);
            }
            recordToInsert.ValidateState();
            await _ansøgerCommand.CreateAsync(recordToInsert);
        }
        public async Task EditAsync(AnsøgerDto ansøger)
        {
            var storedAnsøger = await _ansøgerCommand.GetByIdAsync(ansøger.Id);
            storedAnsøger.SetFornavn(ansøger.Fornavn);
            storedAnsøger.SetEfternavn(ansøger.Efternavn);
            storedAnsøger.SetEmail(ansøger.Email);
            storedAnsøger.ValidateState();
            await _ansøgerCommand.UpdateAsync(storedAnsøger);            
        }
        public async  Task SletAsync(string id)
        {
            var ansøgerToDelete = new Ansøger();
            ansøgerToDelete.SetUserId(id);
            await _ansøgerCommand.DeleteAsync(ansøgerToDelete);
        }
    }
}
