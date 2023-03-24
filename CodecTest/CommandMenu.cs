using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest
{
    public interface ICommandMenu 
    {
        void GameMenuSelection();
    }
    public class CommandMenu : ICommandMenu
    {
        private readonly IInstructionCollection instructions;
        public CommandMenu(IInstructionCollection instructions)
        { 
            this.instructions = instructions;
        }
        public void GameMenuSelection()
        {
            string isActive = "y";

            while (isActive == "y")
            {
                this.instructions.CollectGridAndInstructions();
                Console.WriteLine("Do you want to try again? y/Y for yes n/N for no");
                isActive = Console.ReadLine();
                if (isActive.ToLower() != "y")
                {
                    break;
                }
            }
                  
        }

    }
}
