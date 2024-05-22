using System.Diagnostics;
using System.Linq.Expressions;

namespace Ovning2_flowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till HUVUDMENY!");
            Console.WriteLine("Du får nu flera navigerings alternativ, välj ett av alterantiven");
            Console.WriteLine("Tryck 1 för att fortsätta");
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
    }
}
