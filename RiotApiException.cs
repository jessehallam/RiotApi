using System;
using System.Runtime.Serialization;

namespace RiotApi
{
    [Serializable]
    public class RiotApiException : Exception
    {
        public RiotApiException()
        {
        }

        public RiotApiException(string message) : base(message)
        {
        }

        public RiotApiException(string message, Exception inner) : base(message, inner)
        {
        }

        protected RiotApiException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}