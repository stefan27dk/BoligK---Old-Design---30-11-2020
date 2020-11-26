using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Web.Infrastructure.Request
{
    public interface IAnsøgningCommand
    {
        void Create(object Ansøgning);
        void Delete(string AnsøgningsId);
        void Update(object Ansøgning);
        void Load(string AnsøgningsId);
    }
}
