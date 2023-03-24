using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest.Instructions
{
    public interface ICommand
    {
        string Forward { get; }
        Dictionary<string, int> TurningPosition { get; }
    }

    public class Command : ICommand
    {
        public string Forward => "F";
       
        public Dictionary<string, int> TurningPosition => new Dictionary<string, int>
        {
            { "L", -1},
            { "R", 1},
        };
    }
}
