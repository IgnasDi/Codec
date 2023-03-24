using CodecTest.Compass;
using CodecTest.Instructions;
using CodecTest.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest
{
    public interface IInstructionExecution 
    {
        string DisplayFinalCoordinates(int[] grid, string instructions);
    }
    public class InstructionExecution : IInstructionExecution
    {        
        public string DisplayFinalCoordinates(int[] grid, string instructions)
        {
            var arrayInstructions = instructions.ToArray();
            var currentCoordinates = new int[] { 1, 1 };
            var currentPosition = CardinalDirections.Directions.Where(v => v.Value.Equals("North")).FirstOrDefault();
            var movement = new Movement();
            var position = new Position();
            var command = new Command();

            foreach (var instruction in arrayInstructions)
            {
                if (command.Forward.Equals(instruction.ToString()))
                {
                    var coordinates = movement.CoordinatedIncrementonPosition(currentPosition.Value, currentCoordinates);
                    currentCoordinates = coordinates;
                }
                else if (command.TurningPosition.Where(k => k.Key.Equals(instruction.ToString())).Any())
                {
                    string cardinalPosition = position.CompassDirection(currentPosition.Value, instruction.ToString());
                    currentPosition = CardinalDirections.Directions.Where(v => v.Value.Equals(cardinalPosition)).FirstOrDefault();
                }
                else
                {
                    throw new ArgumentException("No Such Command");
                }

                if (movement.IsMovementOutsideGrid(currentCoordinates, grid))
                {
                    throw new Exception("Robot outside the grid");
                }
            }
            return $"Coordinates: {currentCoordinates[0]}, {currentCoordinates[1]}, Position: {currentPosition.Value}";
        }
    }
}
