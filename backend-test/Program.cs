using System;
using System.Collections.Generic;

namespace backend_test
{
    internal class Program
    {
        private bool CheckChoice(string choice)
        {
            return choice == "q" || choice == "w" || choice == "e";
        }

        private string GetChoice()
        {
            string choice;
            do
            {
                choice = Input.GetStringInput("Please get your choice (q,w,e): ");
                if (!CheckChoice(choice))
                {
                    Console.WriteLine("Please choose the right choice");
                }
            } while (!CheckChoice(choice));
            return choice;
        }

        private string GetComputerChoice()
        {
            Random rnd = new Random();
            int numb = rnd.Next(1, 4);
            switch (numb)
            {
                case 1: return "q";
                case 2: return "w";
                case 3: return "e";
            }
            return "";
        }

        private int ValidateChoice(string p1Choice, string p2Choice)
        {
            if (
                (p1Choice == "q" && p2Choice == "e") ||
                (p1Choice == "w" && p2Choice == "q") ||
                (p1Choice == "e" && p2Choice == "w")
                )
            {
                return 1;
            } else if (
                (p1Choice == "q" && p2Choice == "q") ||
                (p1Choice == "w" && p2Choice == "w") ||
                (p1Choice == "e" && p2Choice == "e")
                ) { 
                return 0;
                }
            return -1;
        }

        private string GetChoiceMap(string choice)
        {
            switch (choice)
            {
                case "q": return "Rock";
                case "w": return "Paper";
                case "e": return "Scissors";
            }
            return "";
        }

        public Program()
        {
            string name = Input.GetStringInput("Please enter your name: ");
            Player player = new Player(name);
            Player computer = new Player("Computer");

            int round = 1;

            Console.WriteLine();
            do
            {
                Console.Write("Round " + round + ": ");

                string choice = GetChoice();
                string computerChoice = GetComputerChoice();

                Console.WriteLine("You choose " + GetChoiceMap(choice) + " Computer choose " + GetChoiceMap(computerChoice));

                int result = ValidateChoice(choice, computerChoice);

                if (result == 1)
                {
                    computer.ReduceHealth();
                    Console.WriteLine("You Win this turn");
                }
                else if(result == 0)
                {
                    Console.WriteLine("Result Draw");
                }
                else
                {
                    player.ReduceHealth();
                    Console.WriteLine("You Lose this turn");
                }

                Console.WriteLine("Remaining Health");
                Console.WriteLine("Player : " + player.Health);
                Console.WriteLine("Computer : " + computer.Health);
                round++;

                Console.WriteLine();
            } while (player.Health != 0 && computer.Health != 0);

            string winner = player.Health == 0 ? computer.Name : player.Name;


            Console.WriteLine("The winner is: " + winner);
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}
