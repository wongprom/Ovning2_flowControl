using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning2.Helpers
{
    public class Util
    {
        public static string AskForString(string prompt)
        {
            bool success = false;
            string answer;

            do
            {
                Console.Write($"{prompt}: ");
                answer = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine($"Din input är fel, försök igen!");
                }
                else
                {
                    success = true;
                }


            } while (!success);

            return answer;
        }

        public static uint AskForUInt(string prompt)
        {
            do
            {
                string input = AskForString(prompt);

                if (uint.TryParse(input, out uint result))
                {
                    return result;
                }

            } while (true);
        }

        public static uint StringToUint(string str)
        {
            do
            {

                if (uint.TryParse(str, out uint result))
                {
                    return result;
                }

            } while (true);
        }


        public static string Ticket(uint age)
        {
            string temp = string.Empty;

           if(age < 20)
            {
                temp = "Ungdomspris: 80kr";
            }
           else if(age <= 64)
            {
                temp = "Standardpris: 120kr"; 
            }
            else
            {
                temp = "Pensionärspris: 90kr";

            }
            return temp;
        }


    }
}
