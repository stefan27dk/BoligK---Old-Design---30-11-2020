using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Infrastructure.Exceptions
{
    public class NoValidNavigationEntityFoundException : Exception
    {
        public NoValidNavigationEntityFoundException(string message) : base(message)
        {
        }
    }
}
