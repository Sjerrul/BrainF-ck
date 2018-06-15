using BrainFck.Machine.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFck.Machine
{
    public class BrainfuckMachine
    {
        private int loopCounter;
        private int instructionPointer;
        private char[] input;
        private string rawInput;

        private int dataPointer;
        private int[] tape;

        private Stack<int> loopInstructionPointers = new Stack<int>();

        public BrainfuckMachine(string input)
        {
            this.loopCounter = 0;
            this.input = input.ToCharArray();
            this.rawInput = input;

            this.instructionPointer = 0;
            this.dataPointer = 0;
            this.tape = new int[] { 0 };
        }

        public void Run(IOutput output)
        {
            while (this.instructionPointer < this.input.Length)
            {
                char instruction = this.input[this.instructionPointer];

                switch (instruction)
                {
                    case '>':
                        this.dataPointer++;
                        if (this.dataPointer >= this.tape.Length)
                        {
                            Array.Resize(ref this.tape, this.tape.Length + 1);
                        }
                        break;
                    case '<':
                        this.dataPointer--;

                        if (this.dataPointer < 0)
                        {
                            int[] newValues = new int[this.tape.Length + 1];
                            newValues[0] = 0;
                            Array.Copy(this.tape, 0, newValues, 1, this.tape.Length);
                            this.tape = newValues;
                            this.dataPointer = 0;
                        }

                        break;
                    case '+':
                        this.tape[this.dataPointer]++;
                        if (this.tape[this.dataPointer] > 255)
                        {
                            this.tape[this.dataPointer] = 0;
                        }
                        break;
                    case '-':
                        this.tape[this.dataPointer]--;
                        if (this.tape[this.dataPointer] < 0)
                        {
                            this.tape[this.dataPointer] = 255;
                        }
                        break;
                    case '.':
                        output.Write(Convert.ToChar(this.tape[this.dataPointer]));
                        break;
                    case '[':
                        if (this.tape[this.dataPointer] == 0)
                        {
                            Stack<char> s = new Stack<char>();
                            s.Push('[');

                            do
                            {
                                this.instructionPointer++;
                                if (this.input[this.instructionPointer] == '[')
                                {
                                    s.Push('[');
                                }

                                if (this.input[this.instructionPointer] == ']')
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
                        if (this.tape[this.dataPointer] != 0)
                        {
                            this.instructionPointer = loopInstructionPointers.Peek();
                        }
                        else
                        {
                            loopInstructionPointers.Pop();
                        }
                        break;
                        //default:
                        //throw new InvalidOperationException("Unknown directive: " + instruction);
                }
                this.instructionPointer++;
            }
        }
    }
}
