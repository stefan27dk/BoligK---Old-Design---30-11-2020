using BoligKø.Web.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Web.Infrastructure.Request
{
    interface IAnsøgerQuery
    {
        AnsøgerDto Get(string UserId);
        ICollection<AnsøgerDto> GetAll();
    }
}
