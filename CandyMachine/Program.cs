// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using CandyMachine;

namespace MyNamespace
{
    class Program
    {
        public static Data dataManager = new Data();
        public static Candy[] candies = dataManager.LoadCandies();

        public static void Main()
        {
            int selection = 0;
            decimal argent = 0m;

            selection = GetSelection(25);
            Candy candy = GetCandy(selection);
            if (candy.Stock == 0)
            {
                Board.Print("vide", result: "enter pour autre choix");
                Console.ReadLine();
                Main();
            }
            else
            {
                Board.Print($"{candy.Name}", selection, candy.Price, 0m, 0m,
                    $"{candy.Stock} en stock");
            }

            do
            {
                argent = GetCoin(argent);
                Board.Print($"{candy.Name}", selection, candy.Price, argent, 0m,
                    $"{candy.Stock} en stock");
            } while (argent < candy.Price);

            if (argent >= candy.Price)
            {
                candy.Stock--;
                Board.Print($"prenez votre bonbon", selection, candy.Price, argent, argent - candy.Price,
                    $"{candy.Stock} en stock");
                Console.ReadLine();
                Main();
            }
        }

        public static int GetSelection(int maxi)
        {
            int selection;
            do
            {
                selection = UserNumberInput("-> votre selection (1-25) : ");
            } while (selection is < 1 || selection > maxi);

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

            return output;
        }

        public static Candy GetCandy(int input)
        {
            return candies[input - 1];
        }

        public static decimal GetCoin(decimal cash)
        {
            Console.WriteLine("[0] = Annuler\n" +
                              "[1] = 5c\n" +
                              "[2] = 10c\n" +
                              "[3] = 25c\n" +
                              "[4] = 1$\n" +
                              "[5] = 2$\n");
            string userinput = Console.ReadLine();


            switch (userinput)
            {
                case "0":
                    if (cash > 0)
                    {
                        Console.Clear();
                        Board.Print($"remboursé ", returned: cash, result: "appuyez sur enter");
                        Console.ReadLine();
                        Main();
                    }
                    else 
                    {
                        Console.Clear();
                        Board.Print(returned: cash, result: "appuyez sur enter");
                        Console.ReadLine();
                        Main();
                    }
                    
                        
                    

                    break;
                case "1":
                    cash += 0.05m;
                    break;
                case "2":
                    cash += 0.10m;
                    break;
                case "3":
                    cash += 0.25m;
                    break;
                case "4":
                    cash += 1m;
                    break;
                case "5":
                    cash += 2m;
                    break;
            }

            return cash;
        }
    }
} /*  */