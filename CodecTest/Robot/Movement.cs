using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodecTest.Compass;

namespace CodecTest.Robot
{
    public interface IMovement 
    {
        bool IsMovementOutsideGrid(int[] currentCordinates, int[] grid);
        int[] CoordinatedIncrementonPosition(string position, int[] currentCoordinates);
    }
    public class Movement : IMovement
    {
        public int[] CoordinatedIncrementonPosition(string position, int[] currentCoordinates)
        {
            if (position.Equals("North"))
            {
                currentCoordinates[1] = currentCoordinates[1] + 1;
            }
            else if (position.Equals("East"))
            {
                currentCoordinates[0] = currentCoordinates[0] + 1;
            }
            else if (position.Equals("South"))
            {
                currentCoordinates[1] = currentCoordinates[1] - 1;
            }
            else if (position.Equals("West"))
            {
                currentCoordinates[0] = currentCoordinates[0] - 1;
            }
            return currentCoordinates;
        }

        public bool IsMovementOutsideGrid(int[] currentCoordinates, int[] grid)
        {
            var isOutsideGrid = false;
            var xAxisCord = currentCoordinates[0];
            var yAxisCord = currentCoordinates[1];
            var xAxis = grid[0];
            var yAxis = grid[1];

            if (xAxisCord < 0 || xAxisCord > xAxis)
            {
                isOutsideGrid = true;
            }
            if (yAxisCord < 0 || yAxisCord > yAxis)
            {
                isOutsideGrid = true;
            }
            return isOutsideGrid;
        }
    }
}
