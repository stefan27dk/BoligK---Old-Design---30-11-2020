using BoligKø.Web.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.Web.Infrastructure.Request
{
    public class AnsøgerQuery:IAnsøgerQuery
    {
        private readonly string url = "https://localhost:5002";
        public async Task<AnsøgerDto> GetAsync(string id)
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url + "/api/ansøger/" + id);

            Json.Deserializer<AnsøgerDto> deserializer = new Json.Deserializer<AnsøgerDto>();
            AnsøgerDto dto = deserializer.Deserialize(json);
            return dto;
        }

        public async Task<ICollection<AnsøgerDto>> GetAllAsync()
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url + "/api/ansøger");

            Json.Deserializer<ICollection<AnsøgerDto>> deserializer = new Json.Deserializer<ICollection<AnsøgerDto>>();
            ICollection<AnsøgerDto> dtos = deserializer.Deserialize(json);
            return new List<AnsøgerDto>();
        }
    }
}
