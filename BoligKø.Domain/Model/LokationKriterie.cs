using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class LokationKriterie:Kriterie
    {
        public int PostNummer { get; set; }
        public LokationKriterie(int postNummer)
        {
            this.PostNummer = postNummer;
            //ValidateState();
        }
        public override void ValidateState()
        {
            throw new NotImplementedException();
        }
    }
}
