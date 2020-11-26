using BoligKø.Web.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoligKø.Web.Infrastructure.Request
{
    public interface IAnsøgerQuery
    {
        Task<AnsøgerDto> GetAsync(string UserId);
        Task<ICollection<AnsøgerDto>> GetAllAsync();
    }
}
