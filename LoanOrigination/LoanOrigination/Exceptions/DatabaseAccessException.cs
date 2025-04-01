using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAppExceptionLib
{
    public class DatabaseAccessException:Exception
    {
        public DatabaseAccessException(string message, Exception innerException) : base(message , innerException) { }
    }
}
