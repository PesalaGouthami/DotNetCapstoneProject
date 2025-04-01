using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAppExceptionLib
{
    public class CustomerException :Exception
    {

        public CustomerException(string message)
            : base(message) { }
    }
}
