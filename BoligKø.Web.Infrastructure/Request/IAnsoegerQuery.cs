﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Web.Infrastructure.Request
{
    interface IAnsoegerQuery
    {
        object Get(string UserId);
    }
}
