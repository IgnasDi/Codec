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
        
        public void GameMenuSelection()
        {
            var instructionCollection = new InstructionCollection();
            string isActive = "y";

            while (isActive == "y")
            {
                instructionCollection.CollectGridAndInstructions();
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
