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
            string isActive = "1";

            while (isActive == "1")
            {
                instructionCollection.CollectGridAndInstructions();
                Console.WriteLine("Do you want to try again? Please enter number 1");
                isActive = Console.ReadLine();
                if (isActive != "1")
                {
                    break;
                }
            }
                  
        }
    }
}
