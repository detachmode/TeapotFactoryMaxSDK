using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeapotFactory.Exceptions
{
    public class ErrorException : Exception
    {
        public ErrorException(string s) : base(s)
        {

        }
    }

    public class WarningException : Exception
    {
        public WarningException(string s) : base(s)
        {

        }
    }
}
