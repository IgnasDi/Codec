using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodecTest.Robot;
using CodecTest.Compass;
using Moq;
using CodecTest.Instructions;

namespace UnitTest
{
    public class WhenRobotPosition
    {
        private ICompassDirections compassDirections = new Mock<ICompassDirections>().Object;

        [Theory]
        [InlineData("North", "L", "West")]
        [InlineData("North", "R", "East")]
        [InlineData("West", "R", "North")]
        [InlineData("West", "L", "South")]
        public void WhenCorrectCardinalPositionSelected(string currentPosition, string rotation, string correctResult)
        {
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
            var result = position.CompassDirection(currentPosition, rotation);
            Assert.Equal(correctResult, result);
        }
    }
}
