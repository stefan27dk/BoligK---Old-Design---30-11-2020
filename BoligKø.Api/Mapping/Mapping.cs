using BoligKø.ApplicationService.Dto;
using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoligKø.Api
{
    public class Mapping
    {
        public static AnsøgerDto MapAnsøger(Ansøger ansøger)
        {
            AnsøgerDto dto = new AnsøgerDto()
            {
                Efternavn = ansøger.Efternavn,
                Fornavn = ansøger.Fornavn,
                Email = ansøger.Email,
                UserId = ansøger.UserId,
                Id = ansøger.Id,
                Ansøgninger = new List<AnsøgningDto>()
            };

            AddAnsøgnings(ansøger.Ansøgninger, dto);

            return dto;
        }

        private static void AddAnsøgnings(IEnumerable<Ansøgning> ansøgnings, AnsøgerDto dto)
        {
            foreach(Ansøgning a in ansøgnings)
            {
                AnsøgningDto ansøgningDto = MapAnsøgning(a);
                dto.Ansøgninger.Add(ansøgningDto);
            }
        }

        public static AnsøgningDto MapAnsøgning(Ansøgning a)
        {
            AnsøgningDto dto = new AnsøgningDto();
            //TODO: Map ansøgningsDto når der er Set metoder på 

            return dto;
            
        }
    }
}
