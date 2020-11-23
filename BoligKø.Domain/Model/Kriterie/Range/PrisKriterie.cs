using BoligKø.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class PrisKriterie : RangeKriterie
    {
        public PrisKriterie(double fra, double til) : base(fra, til)
        {
            //ValidateState();
        }

        public override void ValidateState()
        {
            if (Fra < 0)
                throw new RangeException("Pris fra skal være højere end 0");
            if (Til > 50000)
                throw new RangeException("Pris til kan ikke være højere end 50000");
        }
    }
}
