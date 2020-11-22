using System;
using System.Runtime.Serialization;

namespace BoligKø.Domain.Model
{
    [Serializable]
    internal class AnsøgningsNullException : Exception
    {
        public AnsøgningsNullException()
        {
        }

        public AnsøgningsNullException(string message) : base(message)
        {
        }

        public AnsøgningsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AnsøgningsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}