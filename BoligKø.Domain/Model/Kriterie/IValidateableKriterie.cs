using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model.Kriterie
{
    interface IValidateableKriterie:IKriterie
    {
        void ValidateState();
    }
}
