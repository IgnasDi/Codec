using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest.Instructions
{
    public class Grid
    {
        public Grid (int xAxis, int yAxis )        {
            XAxis = xAxis;
            YAxis = yAxis;
        }

        public int XAxis { get; set; }
        public int YAxis { get; set; }

        public int[] XYGrid()
        {
            return new int[] { XAxis, YAxis };
        }
    }
}
