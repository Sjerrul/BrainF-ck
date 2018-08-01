using Sjerrul.BrainFck.Machine;
using Sjerrul.BrainFck.Machine.Parts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Sjerrul.Brainfck.ConsoleApplication
{
    /*
        > - move to the next cell;
        < - move to the previous cell;
        + - increment the value in the current cell by 1;
        - - decrement the value of the current cell by 1;
        . - output the value of the current cell;
        , - input the value outside and store it in the current cell;
        [ - if the value of the current cell is zero, move forward on the text to the program to] taking into account nesting;
        ] - if the value of the current cell is not zero, go back on the text of the program to [considering nesting;
    */
    class Program
    {


        static void Main(string[] args)
        {
#if DEBUG
            args = new string[] { "input.txt" };
#endif

            if (args.Length != 1)
            {
                Console.WriteLine(String.Format("Usage: '{0} <path_to_file>'", System.AppDomain.CurrentDomain.FriendlyName));
                return;
            }

            BrainfuckMachine machine = new BrainfuckMachine(new ConsoleOutput(), new Tape());

            InputFile file = new InputFile(args[0]);
            string full = string.Concat(file);
            machine.Run(full);

            Console.ReadKey();
        }

        #region Fileparsing

        public class InputFile : IEnumerable<string>
        {
            private readonly IList<string> lines = new List<string>();

            public InputFile(string fileName)
            {
                var file = File.ReadAllLines(fileName);
                foreach (string line in file)
                {
                    this.lines.Add(line);
                }
            }

            public IEnumerator<string> GetEnumerator()
            {
                return GetFileEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetFileEnumerator();
            }

            private IEnumerator<string> GetFileEnumerator()
            {
                foreach (string line in this.lines)
                {
                    yield return line;
                }
            }
        }

        #endregion
    }
}
