using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BoligKø.Domain.Exceptions
{
    [Serializable]
    internal class RangeException : Exception
    {
        public RangeException()
        {
        }

        public RangeException(string message) : base(message)
        {
        }

        public RangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
