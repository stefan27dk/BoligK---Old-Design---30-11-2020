using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoligKø.Web.ViewModels
{
    public class AnsøgerViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Email { get; set; }
        //public IEnumerable<Ansøgning> Ansøgninger { get; set; }

    }
}
