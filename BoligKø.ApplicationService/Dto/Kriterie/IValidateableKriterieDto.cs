using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.ApplicationService.Dto
{
    interface IValidateableKriterieDto:IKriterieDto
    {
        void ValidateState();
    }
}
