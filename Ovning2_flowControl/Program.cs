using Ovning2.Helpers;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Ovning2_flowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Välkommen till Vår Bio!");
            Console.WriteLine($"Du får nu flera navigerings alternativ, välj ett av alterantiven.");
            Console.WriteLine($"Tryck {MenuHelpers.BuyTicket} för att Köpa en biljett.");
            Console.WriteLine($"Tryck {MenuHelpers.BuyTickets} för att Köpa flera biljetter.");
            Console.WriteLine($"Tryck {MenuHelpers.Repeat10Times} för att repetera 10 gånger.");
            Console.WriteLine($"Eller Tryck 0 för att avsluta.");


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
                        break;
                    case MenuHelpers.BuyTickets:
                        Console.WriteLine("För bästa service och pris, behöver vi information");
                        BuyTickets();
                        break;
                    case MenuHelpers.Repeat10Times:
                        Console.WriteLine("Nu ska vi repetera valfri text 10 gånger.");
                        Repeate();
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

        private static void Repeate()
        {
            string input = Util.AskForString("Skriv text du vill repetera: ");
            int repeatNumTimes = 10;
            for (int i = 0; i < repeatNumTimes; i++)
            {
                Console.Write($"{i + 1}.{input},");
            }
        }
        private static void BuyTickets()
        {
            uint totalTickets = Util.AskForUInt("Hur många biljetter vill ni köpa?");
            Console.WriteLine($"Antal biljetter: {totalTickets}");
            uint totalTicketsCost = 0;

            for (int i = 0; i < totalTickets; i++)
            {
                uint age = Util.AskForUInt($"Person nr {i + 1}: Vad är din ålder?");
                string typeOfTicket = Util.Ticket(age);
                uint ticketPrice = Util.StringToUint(string.Concat(typeOfTicket.Where(Char.IsDigit)));
                totalTicketsCost += ticketPrice;

            }
            Console.WriteLine($"Total kostnad för {totalTickets} biljetter blir {totalTicketsCost}kr.");
        }

        private static void BuyTicket()
        {
            uint age = Util.AskForUInt("Vad är din ålder?");
            string typeOfTicket = Util.Ticket(age);
            Console.WriteLine(typeOfTicket);
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
