using BoligKø.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class KvmKriterie : RangeKriterie
    {
        public KvmKriterie(double fra, double til) : base(fra, til)
        {
            ValidateState();
        }

        public override void ValidateState()
        {
            if (Fra < 0)
                throw new RangeException("Kvm fra skal være højere end 0");
            if (Til > 300)
                throw new RangeException("Kvm til kan ikke være højere end 300");

        }
    }

   
}
