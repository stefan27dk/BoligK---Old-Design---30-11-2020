﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public interface IValidateableKriterie:IKriterie
    {
        void ValidateState();
    }
}
