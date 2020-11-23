using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.ApplicationService.Dto
{
    public class AnsøgningDto:BaseEntity
    {
        public AnsøgerDto Ansøger { get;  set; }
        public string ØvrigKommentar { get;  set; }
        public ICollection<IKriterieDto> Kriterier { get;  set; }
        public bool Aktiv { get;  set; }
    }
}
