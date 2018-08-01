using Sjerrul.BrainFck.Machine.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.Brainfck.Cerebrum
{
    public class MemoryOutput : IOutput
    {
        private readonly StringBuilder output;

        public MemoryOutput()
        {
            this.output = new StringBuilder();
        }

        public void Write(char value)
        {
            this.output.Append(value);
        }

        public override string ToString()
        {
            return this.output.ToString();
        }
    }
}
