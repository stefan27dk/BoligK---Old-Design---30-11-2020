﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public abstract class IValidateableKriterie:Kriterie
    {
        public abstract void ValidateState();
    }
}
