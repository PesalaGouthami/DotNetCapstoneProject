using System;

namespace LoanOrigination.Exceptions
{
    public class LoanApplicationException : Exception
    {
        public LoanApplicationException() { }

        public LoanApplicationException(string message): base(message) { }

        public LoanApplicationException(string message, Exception innerException): base(message, innerException) { }
    }
}
