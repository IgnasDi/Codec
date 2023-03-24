using CodecTest.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class WhenGridValidation
    {
        [Theory]
        [InlineData("5x5")]
        [InlineData("25x25")]
        [InlineData("100x100")]
        public void WhenGridEnteredCorrectly(string grid)
        {
            var gridValidation = new GridValidation();
            var result = gridValidation.ValidateGrid(grid);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("kx5")]
        [InlineData("kxk")]
        [InlineData("0x5")]
        [InlineData("5x0")]
        [InlineData("5x-1")]
        [InlineData("-1x5")]
        [InlineData("55")]
        [InlineData("5X5")]
        [InlineData("5k5")]
        [InlineData("x")]
        [InlineData("5x5x5")]
        [InlineData("5X5x")]
        [InlineData("x5x5")]
        [InlineData("25x25x25")]
        public void WhenGridEnteredIncorrectly(string grid)
        {
            var gridValidation = new GridValidation();
            var result = gridValidation.ValidateGrid(grid);
            Assert.False(result.IsValid);
        }
    }
}
