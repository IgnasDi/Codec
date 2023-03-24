using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest.Validation
{
    public static class InstructionValidation
    {
        private static string[] availableInstructions = new string[] { "F", "R", "L" };
                 
        public static string ValidateInstructions()
        {
            bool isValid = false;          
            string validInstructions = String.Empty;
            while (!isValid)
            {
                int numberInvalid = 0;
                var instructions = Console.ReadLine();
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
                    Console.WriteLine("One of the instructions is invalid. Please enter valid instructions");
                    isValid = false;
                }
                else 
                {
                    validInstructions = instructions;
                    break;
                }
            }
            return validInstructions;
            
        }
    }
}
