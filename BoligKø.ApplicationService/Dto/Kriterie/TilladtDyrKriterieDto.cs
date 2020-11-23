using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.ApplicationService.Dto
{
    public class TilladtDyrKriterieDto : IKriterieDto
    {
        public bool SmåDyr { get; private set; }
        public bool StorDyr { get; private set; }
        public TilladtDyrKriterieDto(bool småDyr, bool storDyr)
        {
            SmåDyr = småDyr;
            StorDyr = storDyr;
        }
    }
}
