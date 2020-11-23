using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public abstract class RangeKriterie : Kriterie
    {
        public double Fra { get; set; }
        public double Til { get; set; }
        public RangeKriterie(double fra, double til)
        {
            this.Fra = fra;
            this.Til = til;
            
        }

        public override void ValidateState()
        {
            throw new NotImplementedException();
        }
    }
}
