﻿using System;
using System.Runtime.Serialization;

namespace BoligKø.Domain.Model
{
    [Serializable]
    public class StateException : Exception
    {
        public StateException()
        {
        }

        public StateException(string message) : base(message)
        {
        }

        public StateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}