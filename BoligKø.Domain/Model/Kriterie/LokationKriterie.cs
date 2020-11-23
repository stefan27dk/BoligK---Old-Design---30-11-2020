using BoligKø.Domain.Model.Kriterie;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class LokationKriterie : IValidateableKriterie
    {
        public int PostNummer { get; }
        public LokationKriterie(int postNummer)
        {
            this.PostNummer = postNummer;
            ValidateState();
        }
        public void ValidateState()
        {
            if (PostNummer < 0 || PostNummer > 10000)
            {
                throw new InvalidPostnummerException("Postnummer er ikke gyldigt");
            }
        }
    }
}
