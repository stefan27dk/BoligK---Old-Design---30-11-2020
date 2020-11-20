using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class LokationKriterie:IKriterie
    {
        public int PostNummer { get;  }
        public LokationKriterie(int postNummer)
        {
            this.PostNummer = postNummer;
            ValidateState();
        }
        public void ValidateState()
        {
            throw new NotImplementedException();
        }
    }
}
