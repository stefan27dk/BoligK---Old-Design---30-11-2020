using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class Ansøgning:BaseEntity
    {
        public Ansøger Ansøger { get; set; }
        public string ØvrigKommentar { get; private set; }
        public ICollection<Kriterie> Kriterier { get; private set; }

    }
}
