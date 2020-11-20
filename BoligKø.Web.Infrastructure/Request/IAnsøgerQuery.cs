using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Web.Infrastructure.Request
{
    interface IAnsøgerQuery
    {
        object Get(string UserId);
        ICollection<object> GetAll();
    }
}
