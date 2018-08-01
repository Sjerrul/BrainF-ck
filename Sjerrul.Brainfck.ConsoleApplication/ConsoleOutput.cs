using System;
using Sjerrul.BrainFck.Machine.Parts;

namespace Sjerrul.Brainfck.ConsoleApplication
{
    public class ConsoleOutput : IOutput
    {
        public void Write(char value)
        {
            Console.Write(value);
        }
    }
}
