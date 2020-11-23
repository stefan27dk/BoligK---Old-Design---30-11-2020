using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.ApplicationService.Dto
{
    public class AnsøgerDto:BaseEntity
    {
        public string Email { get; set; }
        public string Fornavn { get;  set; }
        public string Efternavn { get;  set; }
        public string UserId { get;  set; }
        public ICollection<AnsøgningDto> Ansøgninger { get; set; }
    }
}
