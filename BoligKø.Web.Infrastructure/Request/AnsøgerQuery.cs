using BoligKø.Web.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Web.Infrastructure.Request
{
    class AnsøgerQuery:IAnsøgerQuery
    {
        public AnsøgerDto Get(string id)
        {
            return System.Text.Json.JsonSerializer.Deserialize<AnsøgerDto>("{'email':'Stefan@email.dk','fornavn':'Stefan','efternavn':'Popov','userId':'u4','ansøgninger':[]}");
        }

        public ICollection<AnsøgerDto> GetAll()
        {
            return new List<AnsøgerDto>();
        }
    }
}
