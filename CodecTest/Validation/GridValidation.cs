using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecTest.Validation
{
    public static class GridValidation
    {
        public static int ValidateAxis()
        {
            int output;
            int result = 0;
            bool isValid = false;
            while (!isValid)
            {
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    isValid = Int32.TryParse(input, out output);
                    if (!isValid)
                    {
                        Console.WriteLine("Please enter a number");
                    }
                    else 
                    {
                        if (output <= 0)
                        {
                            Console.WriteLine("Please enter a positive greater than 0 number");
                            isValid = false;
                        }
                        else 
                        {
                            result = output;
                            break;
                        }
                    }                   
                }
                else
                {
                    isValid = false;
                }
            }
            return result;
        }

    }
}
