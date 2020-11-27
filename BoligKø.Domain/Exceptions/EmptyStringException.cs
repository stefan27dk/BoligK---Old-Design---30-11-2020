using System;
using System.Runtime.Serialization;

namespace BoligKø.Domain.Model
{
    [Serializable]
    internal class EmptyStringException : Exception
    {
        public EmptyStringException()
        {
        }

        public EmptyStringException(string message) : base(message)
        {
        }

        public EmptyStringException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyStringException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}