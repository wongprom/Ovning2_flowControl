using System.Diagnostics;
using System.Linq.Expressions;

namespace Ovning2_flowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Vår Bio!");
            Console.WriteLine("Du får nu flera navigerings alternativ, välj ett av alterantiven");
            Console.WriteLine("Tryck 1 för att Boka biljett");
            Console.WriteLine("Tryck 0 för att avsluta");


            bool isContinue = true;
            do
            {
                string input = Console.ReadLine()!;
                switch (input)
                {
                    case "0":
                        isContinue = false;
                        Console.WriteLine("Vill inte fortsätta");
                        break;
                    case "1":

                        Console.WriteLine("För bästa service och pris, behöver vi veta din ålder.");
                        YouthOrSenior();
                        
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Du har valt ett alternativ som inte finns, prova igen");
                        Console.WriteLine("Tryck 1 för att fortsätta");
                        Console.WriteLine("Tryck 0 för att avsluta");
                        break;
                }
            }
            while (isContinue);
        }

        public static void YouthOrSenior()
        {
            Console.Write("Ange din ålder: ");
            string age = Console.ReadLine()!;
            int ageConverted;

            if(isStringValid(age))
            {
                ageConverted = ConvertStringToInt(age);
                Console.WriteLine($"Age is converted {ageConverted}");  

            }
            else
            {
                //String is not valid here, make user try input age again.
            }
        }

        public static bool isStringValid(string prompt)
        {
            if(string.IsNullOrWhiteSpace(prompt))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int ConvertStringToInt(string str)
        {
            if(int.TryParse(str, out int result))
            {
                return result;
            }
            else 
            { 
                return 0;
            }
          
        }
    }
}
