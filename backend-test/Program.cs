using System;
using System.Collections.Generic;

namespace backend_test
{
    internal class Program
    {
        private List<Turn> _turns;
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

        private void AddTurn(Player p1, Player p2, string c1, string c2, int result, int round)
        {
            Turn turn = new Turn();

            string winner = "";

            switch (result)
            {
                case 0:
                    winner = "None";
                    break;
                case 1: winner = p1.Name;
                    break;
                case -1: winner = p2.Name;
                    break;
            }

            turn.Winner = winner;
            turn.Round = round;
            turn.RemainingHealthForP1 = p1.Health;
            turn.RemainingHealthForP2 = p2.Health;
            turn.ChoiceForP1 = c1;
            turn.ChoiceForP2 = c2;
            _turns.Add(turn);
        }

        public void ShowTurns(Player  p1, Player p2)
        {
            for(int i = 0; i < _turns.Count; i++)
            {
                Turn t = _turns[i];
                Console.WriteLine("Round " + t.Round);
                Console.WriteLine(p1.Name + " choose " + GetChoiceMap(t.ChoiceForP1) + ","+ p2.Name + " choose " + GetChoiceMap(t.ChoiceForP2));
                Console.WriteLine("Winner :" + t.Winner);
                Console.WriteLine("Remaining Health");
                Console.WriteLine("Player : " + t.RemainingHealthForP1);
                Console.WriteLine("Computer : " + t.RemainingHealthForP2);
                Console.WriteLine();

            }
        }

        public Program()
        {
            string name = Input.GetStringInput("Please enter your name: ");
            Player player = new Player(name);
            Player computer = new Player("Computer");
            _turns = new List<Turn>();

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

                AddTurn(player, computer, choice, computerChoice, result, round++);

                Console.WriteLine();
            } while (player.Health != 0 && computer.Health != 0);

            string winner = player.Health == 0 ? computer.Name : player.Name;

            ShowTurns(player, computer);

            Console.WriteLine("The winner is: " + winner);
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}
