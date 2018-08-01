using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sjerrul.BrainFck.Machine;
using Sjerrul.BrainFck.Machine.Parts;

namespace Sjerrul.Brainfck.Machine.Tests
{
    [TestClass]
    public class BrainfuckMachineTests
    {
        [TestMethod]
        public void Ctor_NullTape_Throws()
        {
            // Arrange
            ITape tape = null;
            IOutput output = new MemoryOutput();

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BrainfuckMachine(output, tape));
        }

        [TestMethod]
        public void Ctor_NullOutput_Throws()
        {
            // Arrange
            ITape tape = new Tape();
            IOutput output = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BrainfuckMachine(output, tape));
        }
    }
}
