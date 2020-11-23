using BoligKø.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class VærelsesKriterie : RangeKriterie
    {
        public VærelsesKriterie(double fra, double til) : base(fra, til)
        {
            ValidateState();
        }

        public override void ValidateState()
        {
            if (Fra < 1)
                throw new RangeException("Minimum 1 værelse");
            if (Til > 6)
                throw new RangeException("Maximum 6 værelser");
        }
    }
}
