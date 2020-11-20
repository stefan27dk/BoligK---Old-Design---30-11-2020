using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class TilladtDyrKriterie : IKriterie
    {
        public bool SmåDyr { get; private set; }
        public bool StorDyr { get; private set; }
        public TilladtDyrKriterie(bool småDyr, bool storDyr)
        {
            SmåDyr = småDyr;
            StorDyr = storDyr;
            ValidateState();
        }
        public void ValidateState()
        {
            throw new NotImplementedException();
        }
    }
}
