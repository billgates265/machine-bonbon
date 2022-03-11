// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using CandyMachine;
using Project;

namespace MyNamespace
{
    class Program
    {
        public static void Main()
        {
            Data dataManager = new Data();
           Candy[] candies = dataManager.LoadCandies(); 
         Console.WriteLine($"{candies[1].Name}");
         Console.WriteLine($"le prix est de {candies[1].Price}");
         Console.WriteLine($"et il en a {candies[1].Stock} en inventaire");
            GetSelection();
        }

        public static void GetSelection()
        {
            byte selection = 0;
            Data dataManager = new Data();
            Candy[] candies = dataManager.LoadCandies();
            do
            {
                Board.Print();
                Console.Write("-> votre selection (1-25) : ");
                selection = byte.Parse(Console.ReadLine());
            } while (selection < 1 || selection > 25);

            if (candies[selection-1].Stock == 0)
            {
                Board.Print("vide");
            }
            else
            {
                Board.Print($"{candies[selection-1].Name}", selection, candies[selection-1].Price, 0m, 0m, "trop pauvre");

            }
        }
        
        
    }
}
