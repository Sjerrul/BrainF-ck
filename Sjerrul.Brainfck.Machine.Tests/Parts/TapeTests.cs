using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sjerrul.BrainFck.Machine.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.Brainfck.Machine.Tests.Parts
{
    [TestClass]
    public class TapeTests
    {
        [TestMethod]
        public void Ctor_IntializesPointerToZero()
        {
            // Act
            Tape tape = new Tape();

            // Assert
            Assert.AreEqual(0, tape.PointerLocation);
        }

        [TestMethod]
        public void Ctor_IntializesTapeLengthToOneCell()
        {
            // Act
            Tape tape = new Tape();

            // Assert
            Assert.AreEqual(1, tape.Length);
        }

        [TestMethod]
        public void MovePointerLeft_FreshyInitializedTape_AddsAxtraCell()
        {
            // Arrange
            Tape tape = new Tape();

            // Act
            tape.MovePointerLeft(); 

            // Assert
            Assert.AreEqual(2, tape.Length);
        }

        [TestMethod]
        public void MovePointerRight_FreshyInitializedTape_AddsExtraCell()
        {
            // Arrange
            Tape tape = new Tape();

            // Act
            tape.MovePointerRight();

            // Assert
            Assert.AreEqual(2, tape.Length);
        }

        [TestMethod]
        public void MovePointerLeft_PointerInNegative_PointerRemainsZeroAndCellAdded()
        {
            // Arrange
            Tape tape = new Tape();

            // Act
            tape.MovePointerLeft();

            // Assert
            Assert.AreEqual(2, tape.Length);
            Assert.AreEqual(0, tape.PointerLocation);
        }

        [TestMethod]
        public void MovePointerRight_FreshyInitializedTape_MovesPointerCorrectly()
        {
            // Arrange
            Tape tape = new Tape();

            // Act
            tape.MovePointerRight();

            // Assert
            Assert.AreEqual(1, tape.PointerLocation);
        }

        [TestMethod]
        public void Increment_FreshyInitializedTape_IncrementsValueAtPointer()
        {
            // Arrange
            Tape tape = new Tape();

            // Act
            tape.Increment();

            // Assert
            Assert.AreEqual(1, tape.Read());
        }

        [TestMethod]
        public void Decrement_PositiveValueInCell_DecrementsValueAtPointer()
        {
            // Arrange
            Tape tape = new Tape();
            tape.Increment(); // Increment first to +1, so decrement won't overflow

            // Act
            tape.Decrement();

            // Assert
            Assert.AreEqual(0, tape.Read());
        }

        [TestMethod]
        public void Decrement_ZeroValueAtPointer_DecrementsValueAtPointer()
        {
            // Arrange
            Tape tape = new Tape();

            // Act
            tape.Decrement();

            // Assert
            Assert.AreEqual(255, tape.Read());
        }

        [TestMethod]
        public void Increment_ValueInCellIsMax_OverflowsToZero()
        {
            // Arrange
            Tape tape = new Tape();

            for (int i = 0; i < Tape.CellMaxValue; i++)
            {
                tape.Increment();
            }

            // Act
            tape.Increment();

            // Assert
            Assert.AreEqual(0, tape.Read());
        }
    }
}
