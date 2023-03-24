using CodecTest.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class WhenInstructionValidation
    {
        [Theory]
        [InlineData("FFL")]
        [InlineData("FLR")]
        [InlineData("LLRF")]
        public void WhenInstructionsEnteredCorrectly(string instructions)
        {
            var instructionValidation = new InstructionValidation();
            var result = instructionValidation.ValidateInstructions(instructions);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("FFLT")]
        [InlineData("FLR0B")]
        [InlineData("LL!RF")]
        public void WhenInstructionsEnteredIncorrectly(string instructions)
        {
            var instructionValidation = new InstructionValidation();
            var result = instructionValidation.ValidateInstructions(instructions);
            Assert.False(result.IsValid);
        }
    }
}
