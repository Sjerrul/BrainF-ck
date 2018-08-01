using System;

namespace Sjerrul.BrainFck.Machine.Parts
{
    public class Tape : ITape
    {
        public static readonly int CellMaxValue = 255;

        private int[] cells;
        private int pointer;

        public int Length => this.cells.Length;

        public int PointerLocation => pointer; 

        public Tape()
        {
            this.cells = new int[] { 0 };
            this.pointer = 0;
        }

        public void MovePointerRight()
        {
            this.pointer++;

            if (this.pointer >= this.cells.Length)
            {
                Array.Resize(ref this.cells, this.cells.Length + 1);
            }
        }

        public void MovePointerLeft()
        {
            this.pointer--;

            if (this.pointer < 0)
            {
                int[] newValues = new int[this.cells.Length + 1];
                newValues[0] = 0;
                Array.Copy(this.cells, 0, newValues, 1, this.cells.Length);
                this.cells = newValues;
                this.pointer = 0;
            }
        }

        public void Increment()
        {
            this.cells[this.pointer]++;
            if (this.cells[this.pointer] > CellMaxValue)
            {
                this.cells[this.pointer] = 0;
            }
        }

        public void Decrement()
        {
            this.cells[this.pointer]--;
            if (this.cells[this.pointer] < 0)
            {
                this.cells[this.pointer] = CellMaxValue;
            }
        }

        public int Read()
        {
            return this.cells[this.pointer];
        }

        public override string ToString()
        {
            return String.Join(" - ", this.cells);
        }
    }
}
