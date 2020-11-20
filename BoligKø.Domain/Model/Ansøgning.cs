using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class Ansøgning:BaseEntity
    {
        public Ansøger Ansøger { get; private set; }
        public string ØvrigKommentar { get; private set; }
        public IEnumerable<IKriterie> Kriterier { get; private set; }
    }
}
