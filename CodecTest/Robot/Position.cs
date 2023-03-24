using CodecTest.Compass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodecTest.Instructions;

namespace CodecTest.Robot
{
    interface IPosition
    {
        string CompassDirection(string currentDirection, string instruction);
    }
    public class Position : IPosition
    {
        public string CompassDirection(string currentDirection, string instruction)
        {
            var moving = new Command();
            var sequence = CardinalDirections.Directions.Count;
            var currentPositionKey = CardinalDirections.Directions.FirstOrDefault(v => v.Value.Equals(currentDirection)).Key;
            var instructionKey = currentPositionKey + moving.TurningPosition.FirstOrDefault(k => k.Key.Equals(instruction)).Value;
            if (instructionKey > sequence)
            {
                return CardinalDirections.Directions.Values.First();
            }
            else if (instructionKey == 0)
            {
                return CardinalDirections.Directions.Values.Last();
            }
            else
            {
                return CardinalDirections.Directions.FirstOrDefault(k => k.Key.Equals(instructionKey)).Value;
            }
        }
    }
}
