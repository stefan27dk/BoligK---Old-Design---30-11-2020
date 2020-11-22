using System;
using System.Runtime.Serialization;

namespace BoligKø.Domain.Model
{
    [Serializable]
    internal class AnsøgningsStateException : Exception
    {
        public AnsøgningsStateException()
        {
        }

        public AnsøgningsStateException(string message) : base(message)
        {
        }

        public AnsøgningsStateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AnsøgningsStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}