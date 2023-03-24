using CodecTest.Instructions;
using CodecTest.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest
{
    public interface IInstructionCollection
    {
        void CollectGridAndInstructions();
    }
    public class InstructionCollection : IInstructionCollection
    {
        string instructions = string.Empty;
        InstructionExecution instructionExecution = new InstructionExecution();

        public void CollectGridAndInstructions()
        {
            Console.WriteLine("Please enter Grid parameters");

            Console.WriteLine("Please enter X Axis:");
            var xAxisInput = GridValidation.ValidateAxis();

            Console.WriteLine("Please enter Y Axis:");
            var yAxisInput = GridValidation.ValidateAxis();
            var grid = new Grid(xAxisInput, yAxisInput);

            Console.WriteLine("Please enter instructions");
            instructions = InstructionValidation.ValidateInstructions();

            var finalCoordinates = instructionExecution.DisplayFinalCoordinates(grid.XYGrid(), instructions);
            Console.WriteLine(finalCoordinates);
        }
    }
}
