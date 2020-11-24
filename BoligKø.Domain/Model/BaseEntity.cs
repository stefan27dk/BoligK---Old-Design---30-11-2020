using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public abstract class BaseEntity
    {
        public string Id { get; protected set; }
    }
}
