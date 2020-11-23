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

        public void ValidateState()
        {
            throw new NotImplementedException();
        }
    }
}
