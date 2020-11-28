using BoligKø.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.ApplicationService.Dto
{
    public class VærelsesKriterieDto : RangeKriterieDto
    {
        public VærelsesKriterieDto(double fra, double til) : base(fra, til)
        {
        }
    }
}
