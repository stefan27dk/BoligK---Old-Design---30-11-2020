﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class TilladtDyrKriterie : Kriterie
    {

        public bool SmåDyr { get; private set; }
        public bool StorDyr { get; private set; }
        public TilladtDyrKriterie(bool småDyr, bool storDyr)
        {
            SmåDyr = småDyr;
            StorDyr = storDyr;
        }
    }
}
