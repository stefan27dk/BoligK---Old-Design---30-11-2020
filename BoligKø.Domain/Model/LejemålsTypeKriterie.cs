﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class LejemålsTypeKriterie:IKriterie
    {
        public LejemålsType LejemålsType { get; }
        public LejemålsTypeKriterie(LejemålsType LejemålsType)
        {
            this.LejemålsType = LejemålsType;
            ValidateState();
        }

        public void ValidateState()
        {
            throw new NotImplementedException();
        }
    }
}
