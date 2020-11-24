using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Web.Infrastructure.Dto
{
    class AnsøgerDto
    {
        public string Email { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string UserId { get; set; }
        public IEnumerable<object> Ansøgninger { get; set; }
    }
}
