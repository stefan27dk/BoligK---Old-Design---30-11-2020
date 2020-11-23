using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.ApplicationService.Dto
{
    public class AnsøgningDto
    {
        public AnsøgerDto Ansøger { get; private set; }
        public string ØvrigKommentar { get; private set; }
        public IEnumerable<IKriterieDto> Kriterier { get; private set; }
        public bool Aktiv { get; private set; }
    }
}
