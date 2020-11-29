using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BoligKø.ApplicationService.Dto
{
    public class AnsøgningDto:BaseEntity
    {
        [JsonIgnore]
        public AnsøgerDto Ansøger { get;  set; }
        public string ØvrigKommentar { get;  set; }
        public ICollection<IKriterieDto> Kriterier { get;  set; }
        public bool Aktiv { get;  set; }
    }
}
