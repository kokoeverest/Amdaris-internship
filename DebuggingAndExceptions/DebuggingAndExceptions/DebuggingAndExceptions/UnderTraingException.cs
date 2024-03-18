using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    internal class UnderTraingException : Exception
    {
        public UnderTraingException() { }
        public UnderTraingException(string message) : base(message) { }
    }
}
