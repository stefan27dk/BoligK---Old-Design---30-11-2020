using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class LejemålsTypeKriterie:Kriterie
    {
        public LejemålsType LejemålsType { get; }
        public LejemålsTypeKriterie() { }
        public LejemålsTypeKriterie(LejemålsType LejemålsType)
        {
            this.LejemålsType = LejemålsType;
        }
    }
}
