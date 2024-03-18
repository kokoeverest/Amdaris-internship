using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    internal class RaceExistExeption : Exception
    {
        public RaceExistExeption() { }
        public RaceExistExeption(string message) : base(message) { }
    }
}
