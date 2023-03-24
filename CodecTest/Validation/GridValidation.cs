using CodecTest.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest.Validation
{
    public interface IGridValidation 
    {
        (bool IsValid, Grid Grid) ValidateGrid(string grid);
    }
    public class GridValidation : IGridValidation
    {
        public (bool IsValid, Grid Grid) ValidateGrid(string grid)
        {
            int output;
            var finalGrid = new Grid(0,0);
            int[] gridValues = new int[2];
            bool isValid = false;
            var XYAxis = grid.Split("x");

            for (int i = 0;  i < gridValues.Length; i++)
            {
                isValid = Int32.TryParse(XYAxis[i], out output);
                if (isValid && output > 0)
                {
                    gridValues[i] = output;
                }
                else 
                {
                    isValid = false;
                    return (isValid, finalGrid);
                }
            }
            finalGrid.XAxis = gridValues[0];
            finalGrid.YAxis = gridValues[1];
            isValid = true;
            return (isValid, finalGrid);
        }

        

    }
}
