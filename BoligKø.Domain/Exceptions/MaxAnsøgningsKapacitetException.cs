using System;
using System.Runtime.Serialization;

namespace BoligKø.Domain.Model
{
    [Serializable]
    public class MaxAnsøgningsKapacitetException : Exception
    {
        public MaxAnsøgningsKapacitetException()
        {
        }

        public MaxAnsøgningsKapacitetException(string message) : base(message)
        {
        }

        public MaxAnsøgningsKapacitetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MaxAnsøgningsKapacitetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}