using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodecTest.Robot;

namespace UnitTest
{
    public class WhenRobotPosition
    {
        [Theory]
        [InlineData("North", "L", "West")]
        [InlineData("North", "R", "East")]
        [InlineData("West", "R", "North")]
        [InlineData("West", "L", "South")]
        public void WhenCorrectCardinalPositionSelected(string currentPosition, string rotation, string correctResult)
        {
            var position = new Position();
            var result = position.CompassDirection(currentPosition, rotation);
            Assert.Equal(correctResult, result);
        }
    }
}
