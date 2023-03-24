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
        string DisplayFinalCoordinates(Grid grid, string instructions);
    }
    public class InstructionExecution : IInstructionExecution
    {
        private readonly IMovement movement;
        private readonly IPosition position;
        private readonly ICommand command;
        private readonly ICompassDirections compassDirections;
        public InstructionExecution(IMovement movement, IPosition position, ICommand command, ICompassDirections compassDirections)
        {
            this.movement = movement;
            this.position = position;
            this.command = command;
            this.compassDirections = compassDirections;
        }
        public string DisplayFinalCoordinates(Grid grid, string instructions)
        {
            var arrayInstructions = instructions.ToArray();
            var currentCoordinates = new int[] { 1, 1 };
            var currentPosition = this.compassDirections.Directions.Where(v => v.Value.Equals("North")).FirstOrDefault();
            var gridValues = new int[] { grid.XAxis, grid.XAxis };

            foreach (var instruction in arrayInstructions)
            {
                if (command.Forward.Equals(instruction.ToString()))
                {
                    var coordinates = this.movement.CoordinatedIncrementonPosition(currentPosition.Value, currentCoordinates);
                    currentCoordinates = coordinates;
                }
                else if (this.command.TurningPosition.Where(k => k.Key.Equals(instruction.ToString())).Any())
                {
                    string cardinalPosition = this.position.CompassDirection(currentPosition.Value, instruction.ToString());
                    currentPosition = this.compassDirections.Directions.Where(v => v.Value.Equals(cardinalPosition)).FirstOrDefault();
                }
                else
                {
                    throw new ArgumentException("No Such Command");
                }

                if (this.movement.IsMovementOutsideGrid(currentCoordinates, gridValues))
                {
                    throw new Exception("Robot outside the grid");
                }
            }
            return $"Coordinates: {currentCoordinates[0]}, {currentCoordinates[1]}, Position: {currentPosition.Value}";
        }
    }
}
