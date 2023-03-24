using CodecTest.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest.Validation
{
    public interface IInstructionValidation
    {
        (bool IsValid, string Instructions) ValidateInstructions(string instructions);
    }
    public class InstructionValidation : IInstructionValidation
    {
        private string[] availableInstructions = new string[] { "F", "R", "L" };
                 
        public (bool IsValid, string Instructions) ValidateInstructions(string instructions)
        {
            bool isValid = false;          
            string validInstructions = String.Empty;
            int numberInvalid = 0;
            foreach (var instruction in instructions)
            {
                isValid = !availableInstructions.Any(i => string.Compare(i, instruction.ToString(), true) == 0) ? false : true;
                if (!isValid)
                {
                    numberInvalid++;
                }
            }
            if (numberInvalid > 0)
            {
                isValid = false;
                return (isValid, instructions);
            }
            else
            {
                isValid = true;
                return (isValid, instructions);
            }

        }
    }
}
