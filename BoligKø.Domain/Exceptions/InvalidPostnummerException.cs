using System;
using System.Runtime.Serialization;

namespace BoligKø.Domain.Model
{
    [Serializable]
    internal class InvalidPostnummerException : Exception
    {
        public InvalidPostnummerException()
        {
        }

        public InvalidPostnummerException(string message) : base(message)
        {
        }

        public InvalidPostnummerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPostnummerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}