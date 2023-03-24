using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodecTest;
using CodecTest.Instructions;
using Moq;
using CodecTest.Robot;
using CodecTest.Compass;

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
            var movement = new Movement();           
            var command = new Mock<ICommand>();
            var compassDirections = new Mock<ICompassDirections>();
            command.Setup(m => m.Forward).Returns("F");
            command.Setup(m => m.TurningPosition).Returns(new Dictionary<string, int>
            {
                { "L", -1},
                { "R", 1},
            });
            compassDirections.Setup(m => m.Directions).Returns(new Dictionary<int, string>
            {
                { 1, "North" },
                { 2, "East" },
                { 3, "South" },
                { 4, "West" },
            });
            var position = new Position(compassDirections.Object, command.Object);
            var instructionExecution = new InstructionExecution(movement, position, command.Object, compassDirections.Object);
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
            var movement = new Movement();
            var command = new Mock<ICommand>();
            var compassDirections = new Mock<ICompassDirections>();
            command.Setup(m => m.Forward).Returns("F");
            command.Setup(m => m.TurningPosition).Returns(new Dictionary<string, int>
            {
                { "L", -1},
                { "R", 1},
            });
            compassDirections.Setup(m => m.Directions).Returns(new Dictionary<int, string>
            {
                { 1, "North" },
                { 2, "East" },
                { 3, "South" },
                { 4, "West" },
            });
            var position = new Position(compassDirections.Object, command.Object);
            var instructionExecution = new InstructionExecution(movement, position, command.Object, compassDirections.Object);
            var grid = new Grid(5, 5);
            Assert.Throws<Exception>(() => { var result = instructionExecution.DisplayFinalCoordinates(grid, instructions); });
        }
    }
}
