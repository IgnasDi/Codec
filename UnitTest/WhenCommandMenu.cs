using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodecTest;
using CodecTest.Instructions;

namespace UnitTest
{
    public class WhenCommandMenu
    {
        [Theory]
        [InlineData("FRFFLFL", "Coordinates: 3, 3, Position: West")]
        [InlineData("RFLFFR", "Coordinates: 2, 3, Position: East")]
        [InlineData("RFLFFRFFLFF", "Coordinates: 4, 5, Position: North")]
        public void WhenDisplayFinalCoordinatesCorrect(string instructions, string finalCoordinates)
        {
            var instructionExecution = new InstructionExecution();
            var grid = new Grid(5, 5);
            var result = instructionExecution.DisplayFinalCoordinates(grid, instructions);           
            Assert.Equal(result, finalCoordinates);
        }

        [Theory]
        [InlineData("FFFFFF")]
        [InlineData("FFFFFFRFLFFR")]
        [InlineData("FFFRFLFFRFFLFF")]
        public void WhenDisplayFinalCoordinatesOutsideGrid(string instructions)
        {
            var instructionExecution = new InstructionExecution();
            var grid = new Grid(5, 5);
            Assert.Throws<Exception>(() => { var result = instructionExecution.DisplayFinalCoordinates(grid, instructions); });

        }
    }
}
