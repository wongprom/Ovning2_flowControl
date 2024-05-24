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
            Console.WriteLine($"Tryck {MenuHelpers.SplitSentence} för att plocka ur tredje ordet i en mening.");
            Console.WriteLine($"Eller Tryck {MenuHelpers.Quit} för att avsluta.");


            bool isContinue = true;
            do
            {
                string input = Console.ReadLine() ?? string.Empty;
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
                    case MenuHelpers.SplitSentence:
                        Console.WriteLine("Nu ska vi hitta tredje ordet.");
                        ThirdWord();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Du har valt ett alternativ som inte finns, prova igen");
                        Console.WriteLine($"Tryck {MenuHelpers.BuyTicket} för att Köpa en biljett.");
                        Console.WriteLine($"Tryck {MenuHelpers.BuyTickets} för att Köpa flera biljetter.");
                        Console.WriteLine($"Tryck {MenuHelpers.Repeat10Times} för att repetera 10 gånger.");
                        Console.WriteLine($"Tryck {MenuHelpers.SplitSentence} för att plocka ur tredje ordet i en mening.");
                        Console.WriteLine($"Eller Tryck {MenuHelpers.Quit} för att avsluta.");
                        break;
                }
            }
            while (isContinue);
        }

        private static void ThirdWord()
        {
            int minimumWords = 3;
            int wordIndex = 2;
            string prompt = $"Skriv en mening som innehåller minst {minimumWords} ord: ";
            bool lessThenMinimumWords = true;
            string input = Util.AskForString(prompt);

            do
            {
                string[] splitInput = input.Split(' ');

                if(input.Split(' ').Length < minimumWords)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    prompt = $"Din mening {input.ToUpper()} innehåller {splitInput.Length} ord, vilket är mindre än {minimumWords} ord, försök igen!";
                    input = Util.AskForString(prompt);
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine($"Ord {wordIndex + 1} för din mening är: {splitInput[wordIndex]}");
                    lessThenMinimumWords = false;
                }
            } while (lessThenMinimumWords);
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
    }
}
