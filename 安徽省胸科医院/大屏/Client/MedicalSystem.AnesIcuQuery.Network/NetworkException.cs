using System;
using System.Runtime.Serialization;

namespace MedicalSystem.AnesIcuQuery.Network
{
    public class NetworkException : Exception
    {
        public NetworkException()
            : base() { }

        public NetworkException(string message)
            : base(message) { }

        protected NetworkException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public NetworkException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
