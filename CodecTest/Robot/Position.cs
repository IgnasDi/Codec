using CodecTest.Compass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodecTest.Instructions;

namespace CodecTest.Robot
{
    public interface IPosition
    {
        string CompassDirection(string currentDirection, string instruction);
    }
    public class Position : IPosition
    {
        private readonly ICompassDirections compassDirections;
        private  readonly ICommand command;
        public Position(ICompassDirections compassDirections, ICommand command)
        {
            this.compassDirections = compassDirections;
            this.command = command;
        }
        public string CompassDirection(string currentDirection, string instruction)
        {
            var sequence = this.compassDirections.Directions.Count;
            var currentPositionKey = this.compassDirections.Directions.FirstOrDefault(v => v.Value.Equals(currentDirection)).Key;
            var instructionKey = currentPositionKey + this.command.TurningPosition.FirstOrDefault(k => k.Key.Equals(instruction)).Value;
            if (instructionKey > sequence)
            {
                return this.compassDirections.Directions.Values.First();
            }
            else if (instructionKey == 0)
            {
                return this.compassDirections.Directions.Values.Last();
            }
            else
            {
                return this.compassDirections.Directions.FirstOrDefault(k => k.Key.Equals(instructionKey)).Value;
            }
        }
    }
}
