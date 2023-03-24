using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest.Instructions
{
    public class Command
    {
        public string Forward => "F";
       
        public Dictionary<string, int> TurningPosition => new Dictionary<string, int>
        {
            { "L", -1},
            { "R", 1},
        };
    }
}
