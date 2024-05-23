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


    }
}
