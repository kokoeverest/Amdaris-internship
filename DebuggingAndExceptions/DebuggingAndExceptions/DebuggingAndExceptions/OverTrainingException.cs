using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    internal class OverTrainingException : Exception
    {
        public OverTrainingException() { }
        public OverTrainingException(string message) : base(message) { }
    }
}
