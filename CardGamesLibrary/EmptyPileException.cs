using System;
using System.Runtime.Serialization;

namespace CardGamesLibrary
{
    [Serializable]
    class EmptyPileException : Exception
    {
        public EmptyPileException()
        {
        }

        public EmptyPileException(string message) : base(message)
        {
        }

        public EmptyPileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyPileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
