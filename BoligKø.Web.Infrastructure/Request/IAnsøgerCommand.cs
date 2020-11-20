using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Web.Infrastructure.Request
{
    interface IAnsøgerCommand
    {
        void Create(object Ansøger);
        void Delete(string UserId);
        void Update(object Ansøger);
        object Load(string UserId);
    }
}
