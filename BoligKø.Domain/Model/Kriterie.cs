using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public abstract class Kriterie : BaseEntity
    {
        public abstract void ValidateState();
    }
}
