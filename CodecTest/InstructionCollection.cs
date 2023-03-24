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
        private readonly IInstructionExecution  instructionExecution;
        public InstructionCollection(IInstructionExecution instructionExecution)
        { 
            this.instructionExecution = instructionExecution;
        }
        public void CollectGridAndInstructions()
        {
            
            Console.WriteLine("Please enter Grid parameters");
            Console.WriteLine("----------------------------");            
            var grid = RunGridCommands();                      
            var instructions = RunInstructionCommands();

            var finalCoordinates = instructionExecution.DisplayFinalCoordinates(grid, instructions);
            Console.WriteLine(finalCoordinates);
        }

        private string RunInstructionCommands()
        {
            InstructionValidation instructionValidation = new InstructionValidation();
            bool isLoop = false;
            string instructions = string.Empty;
            while (!isLoop)
            {
                Console.WriteLine("Please enter correct instructions");
                var input = Console.ReadLine();
                var result = instructionValidation.ValidateInstructions(input);
                if (result.IsValid)
                {
                    instructions = result.Instructions;
                    isLoop = result.IsValid;
                }
            }
            return instructions;
        }

        private Grid RunGridCommands()
        {
            GridValidation gridValidation = new GridValidation();
            bool isLoop = false;
            Grid grid = null;
            while (!isLoop)
            {
                Console.WriteLine("Please enter a grid size (example NxN) numbers should be greater than 0:");
                var gridInput = Console.ReadLine();
                var result = gridValidation.ValidateGrid(gridInput);
                if (result.IsValid)
                {
                    grid = result.Grid;
                    isLoop = result.IsValid;
                }
            }
            return grid;
        }
    }
}
