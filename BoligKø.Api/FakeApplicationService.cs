using BoligKø.ApplicationService;
using BoligKø.ApplicationService.Dto;
using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.patterns;
using BoligKø.Infrastructure.Queries.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoligKø.Api
{
    public class FakeApplicationService:IAnsøgerApplicationService
    {
        List<AnsøgerDto> ansøgers = new List<AnsøgerDto>()
        {
            new AnsøgerDto()
            {

                Ansøgninger = new List<AnsøgningDto>(),
                Fornavn = "Martin",
                Efternavn = "Sørensen",
                Email = "Martin@email.dk",
                UserId = "u1"
            },
            new AnsøgerDto()
            {
                Ansøgninger = new   List<AnsøgningDto>(),
                Fornavn = "Nichlas",
                Efternavn = "Bo",
                Email = "Nichlas@email.dk",
                UserId = "u2"
            },
            new AnsøgerDto()
            {
                Ansøgninger = new   List<AnsøgningDto>(),
                Fornavn = "Karl",
                Efternavn = "Mogensen",
                Email = "Karl@email.dk",
                UserId = "u3"
            },
            new AnsøgerDto()
            {
                 Ansøgninger = new   List<AnsøgningDto>(),
                Fornavn = "Stefan",
                Efternavn = "Popov",
                Email = "Stefan@email.dk",
                UserId = "u4"
            }
        };

        public Task EditAsync(AnsøgerDto ansøger)
        {
            return null;
        }

        //public async Task<IEnumerable<AnsøgerDto>> GetAllAsync()
        //{
        //    //await Task.Run(() => Console.WriteLine("Task"));
        //    return ansøgers;
        //}

        //public async Task<AnsøgerDto> GetAsync(string id)
        //{
        //    return ansøgers.Where(a => a.UserId == id).FirstOrDefault();
        //}

        public async Task SletAsync(AnsøgerDto dto)
        {
            AnsøgerDto dto2 = ansøgers.Where(a => a.UserId == dto.UserId).FirstOrDefault();
            ansøgers.Remove(dto2);
        }
        public async Task OpretAsync(AnsøgerDto dto)
        {
            ansøgers.Add(dto);
        }

        //private readonly IAnsøgerQuery _ansøgerQuery;
        //private readonly Repository<Ansøger> _ansøgerRepository;
        //public FakeApplicationService(IAnsøgerQuery query, BoligKøContext context)
        //{
        //    _ansøgerQuery = query;
        //    _ansøgerRepository = new Repository<Ansøger>(context);
        //}

        //public async Task<AnsøgerDto> GetAnsøgerAsync(string id)
        //{
        //    await Task.Run(() =>
        //    {
        //        Ansøger ansøg = _ansøgerQuery.GetById(id);

        //        if (ansøg == null) throw new Exception("Not found");

        //        AnsøgerDto dto = CreateDto(ansøg);
        //        return dto;
        //    });

        //    return null;
        //}

        //public async Task SletAnsøgerAsync(string id)
        //{
        //    Ansøger ansøg = _ansøgerQuery.GetById(id);

        //    if (ansøg == null) throw new Exception("Not found");

        //    await _ansøgerRepository.DeleteAsync(ansøg);
        //}



        //private AnsøgerDto CreateDto(Ansøger ansøg)
        //{
        //    AnsøgerDto dto = new AnsøgerDto()
        //    {
        //        Fornavn = ansøg.Fornavn,
        //        Efternavn = ansøg.Efternavn,
        //        Email = ansøg.Email,
        //        UserId = ansøg.UserId
        //    };

        //    return dto;
        //}
    }
}
