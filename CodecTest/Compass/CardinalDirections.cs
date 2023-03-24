using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest.Compass
{
    public static class CardinalDirections
    {
        public static Dictionary<int, string> Directions => new Dictionary<int, string> {
            { 1, "North" },
            { 2, "East" },
            { 3, "South" },
            { 4, "West" },
        };
    }
}
