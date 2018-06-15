using BrainFck.Machine.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFck
{
    public class ConsoleOutput : IOutput
    {
        public void Write(char value)
        {
            Console.Write(value);
        }
    }
}
