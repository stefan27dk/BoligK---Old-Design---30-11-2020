using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Web.Infrastructure.Request
{
    interface IAnsøgningQuery
    {
        object Get(string AnsøgningsId);
        ICollection<object> GetAll();
    }
}
