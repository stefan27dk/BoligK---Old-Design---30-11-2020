using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    class VærelsesKriterie : RangeKriterie
    {
        public VærelsesKriterie(double fra, double til) : base(fra, til)
        {
            ValidateState();
        }

        public override void ValidateState()
        {
            throw new NotImplementedException();
        }
    }
}
