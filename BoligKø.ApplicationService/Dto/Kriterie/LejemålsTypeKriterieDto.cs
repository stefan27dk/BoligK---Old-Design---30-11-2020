using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.ApplicationService.Dto
{
    public class LejemålsTypeKriterieDto:IKriterieDto
    {
        public LejemålsType LejemålsType { get; }
        public LejemålsTypeKriterieDto(LejemålsType LejemålsType)
        {
            this.LejemålsType = LejemålsType;
        }
    }
}
