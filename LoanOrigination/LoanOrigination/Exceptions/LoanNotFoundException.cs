using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAppExceptionLib
{
    public class LoanNotFoundException:Exception
    {
        public LoanNotFoundException(string message) : base(message) { }
    }
}
