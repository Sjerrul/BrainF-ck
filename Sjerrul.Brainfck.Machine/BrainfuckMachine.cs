using Sjerrul.BrainFck.Machine.Parts;
using System;
using System.Collections.Generic;

namespace Sjerrul.BrainFck.Machine
{
    public class BrainfuckMachine
    {
        private int instructionPointer;

        private readonly ITape tape;
        private readonly IOutput output;

        private readonly Stack<int> loopInstructionPointers = new Stack<int>();

        public BrainfuckMachine(IOutput output, ITape tape)
        {
            this.output = output ?? throw new ArgumentNullException(nameof(output));
            this.tape = tape ?? throw new ArgumentNullException(nameof(tape));

            this.instructionPointer = 0;
        }

        public void Run(string input)
        {
            int executions = 0;
            while (this.instructionPointer < input.Length)
            {
                char instruction = input[this.instructionPointer];

                switch (instruction)
                {
                    case '>':
                        this.tape.MovePointerRight();
                        break;
                    case '<':
                        this.tape.MovePointerLeft();
                        break;
                    case '+':
                        this.tape.Increment();
                        break;
                    case '-':
                        this.tape.Decrement();
                        break;
                    case '.':
                        output.Write(Convert.ToChar(this.tape.Read()));
                        break;
                    case '[':
                        if (this.tape.Read() == 0)
                        {
                            Stack<char> s = new Stack<char>();
                            s.Push('[');

                            do
                            {
                                this.instructionPointer++;
                                if (input[this.instructionPointer] == '[')
                                {
                                    s.Push('[');
                                }

                                if (input[this.instructionPointer] == ']')
                                {
                                    s.Pop();
                                }

                            } while (s.Count != 0);
                        }
                        else
                        {
                            this.loopInstructionPointers.Push(this.instructionPointer);
                        }
                        break;
                    case ']':
                        if (this.tape.Read() != 0)
                        {
                            this.instructionPointer = loopInstructionPointers.Peek();
                        }
                        else
                        {
                            loopInstructionPointers.Pop();
                        }
                        break;
                }
                this.instructionPointer++;
                executions++;

                if(executions > 10000)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
