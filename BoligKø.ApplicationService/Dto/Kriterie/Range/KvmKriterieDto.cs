using BoligKø.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BoligKø.ApplicationService.Dto
{
    public class KvmKriterieDto : RangeKriterieDto
    { 
        public KvmKriterieDto(double fra, double til) : base(fra, til)
        {
        }

    }

   
}
