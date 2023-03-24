using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodecTest.Robot;

namespace UnitTest
{
    public class WhenRobotMovement
    {
        [Theory]
        [InlineData("North", new int[] { 4, 5 })]
        [InlineData("East", new int[] { 5, 4 })]
        [InlineData("South", new int[] { 4, 3 })]
        [InlineData("West", new int[] { 3, 4 })]
        public void CoordinatedIncrementonPosition(string position, int[] finalposition)
        {
            var movement = new Movement();
            var currentPosition = new int[] { 4, 4 };
            var result = movement.CoordinatedIncrementonPosition(position, currentPosition);
            Assert.Equal(finalposition, result);
        }

        [Theory]
        [InlineData(new int[] { 6, 5 })]
        [InlineData(new int[] { -1, 5 })]
        [InlineData(new int[] { 5, 6 })]
        [InlineData(new int[] { 5, -1 })]
        public void WhenCoordinatesOutsideGrid(int[] coordinates)
        {
            var grid = new int[] { 5, 5 };
            var movement = new Movement();
            var result = movement.IsMovementOutsideGrid(coordinates, grid);
            Assert.True(result);
        }

        [Theory]
        [InlineData(new int[] { 0, 0 })]
        [InlineData(new int[] { 1, 5 })]
        [InlineData(new int[] { 5, 5 })]
        [InlineData(new int[] { 5, 1 })]
        public void WhenCoordinatesInsideGrid(int[] coordinates)
        {
            var grid = new int[] { 5, 5 };
            var movement = new Movement();
            var result = movement.IsMovementOutsideGrid(coordinates, grid);
            Assert.False(result);
        }
    }
}
