using Ovning2.Helpers;
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
                    case MenuHelpers.Quit:
                        isContinue = false;
                        Console.WriteLine("Vill inte fortsätta");
                        break;
                    case MenuHelpers.BuyTicket:
                        Console.WriteLine("För bästa service och pris, behöver vi veta din ålder.");
                        BuyTicket();
                        //YouthOrSenior();
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

        private static void BuyTicket()
        {
            uint age = Util.AskForUInt("Vad är din ålder?");
        }

        public static void YouthOrSenior()
        {
            Console.Write("Ange din ålder: ");
            string age = Console.ReadLine()!;
            int ageConverted = 0;

            if(isStringValid(age))
            {   
                ageConverted = ConvertStringToInt(age);
                Console.WriteLine($"Age is converted {ageConverted}");  

            }
            else
            {
                //String is not valid here, make user try input age again.
            }

            if(ageConverted >= 0 && ageConverted < 20)
            {
                Console.WriteLine($"Ungdomspris: 80kr");  
            }
            else if (ageConverted > 64)
            { 
                Console.WriteLine($"Pensionärspris: 90kr");             
            }
            else
            {
                Console.WriteLine($"Standardpris: 120kr");  
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
