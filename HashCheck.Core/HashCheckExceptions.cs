using System;

namespace HashCheck.Core
{
    public class InvalidHashKindException : Exception
    {
        public InvalidHashKindException() { }
        public InvalidHashKindException(string message) : base(message) { }
        public InvalidHashKindException(string message, Exception inner) : base(message, inner) { }
    }
}
