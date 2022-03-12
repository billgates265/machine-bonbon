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
            int selection = 0;
            Data dataManager = new Data();
            Candy[] candies = dataManager.LoadCandies();

            GetSelection(selection);
        }

        public static int GetSelection(int selection)
        {
            do
            { 
                selection =  UserNumberInput("-> votre selection (1-25) : ");
                
            } while ((selection < 1) || (selection > 25));
            
            return selection;
        }
        public static int UserNumberInput(string texte)
        {
            // === Variable declaration
            int output;
            bool tryParse;
            // === Function main

            do
            {
                Console.Clear();
                Board.Print();
                Console.Write(texte);
                tryParse = int.TryParse(Console.ReadLine(), out output);
            } while (!tryParse);

            return (output);
        }
    }
} /*  if (candies[selection - 1].Stock == 0)
                  {
                      Board.Print("vide");
                  }
                  else
                  {
                      Board.Print($"{candies[selection - 1].Name}", selection, candies[selection - 1].Price, 0m, 0m,
                          "trop pauvre");
                  }*/