using System.Diagnostics.Contracts;

namespace GuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
  ________                                                  ._. 
 /  _____/  __ __   ____    ______  ______ __ __  ______    | | 
/   \  ___ |  |  \_/ __ \  /  ___/ /  ___/|  |  \/  ___/    | | 
\    \_\  \|  |  /\  ___/  \___ \  \___ \ |  |  /\___ \      \| 
 \______  /|____/  \___  >/____  >/____  >|____//____  >     __ 
        \/             \/      \/      \/            \/      \/ 
              
    Weclome to the guessing game!
    -----------------------------
    enter start to advance.
");
             // starting the game.
             if (Console.ReadLine() != "start")
             {
                ExitGame("[!] unknown input!");
             } else
            {
                Game();
            }

            
        }
        static void Failure(int luckyNumber)
        {
            Console.Clear();
            Console.WriteLine(@"
  ________                              ________                        ._. 
 /  _____/ _____     _____    ____      \_____  \ ___  __  ____ _______ | | 
/   \  ___ \__  \   /     \ _/ __ \      /   |   \\  \/ /_/ __ \\_  __ \| | 
\    \_\  \ / __ \_|  Y Y  \\  ___/     /    |    \\   / \  ___/ |  | \/ \| 
 \______  /(____  /|__|_|  / \___  >    \_______  / \_/   \___  >|__|    __ 
        \/      \/       \/      \/             \/            \/         \/ 

");
            Console.WriteLine("The number was {0} !", luckyNumber);

            Console.WriteLine("\nGood luck next time :)");
            PlayAgain();
        }
        static void Congrats(int luckyNumber)
        {
            Console.Clear();
            Console.WriteLine(@"
_____.___.                            .__        ._. 
\__  |   |  ____   __ __     __  _  __|__|  ____ | | 
 /   |   | /  _ \ |  |  \    \ \/ \/ /|  | /    \| | 
 \____   |(  <_> )|  |  /     \     / |  ||   |  \\| 
 / ______| \____/ |____/       \/\_/  |__||___|  /__ 
 \/                                            \/ \/ 
                                                     
");
            Console.WriteLine("The number was {0} !", luckyNumber);
            Console.WriteLine("\nPlay again!");
            PlayAgain();
        }

        static void Game()
        {
            Console.Clear();

            // generating a random integer between 1 and 100.
            Random random = new Random();
            int randNum = random.Next(1, 100);

            // difficulty settings.
            Console.Write("[difficulty] (easy/med/hard)>");
            string difficulty = Console.ReadLine();
            int tries = 0;
            switch (difficulty.ToLower())
            {
                case "easy":
                    tries = 12;
                    break;
                case "med":
                    tries = 6;
                    break;
                case "hard":
                    tries = 3;
                    break;
                default:
                    ExitGame("[!] unknown input!");
                    break;
            }
            // the game loop.
            string hint = "the number is between 1 and 100";
            for (int i = tries; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine(@"
  ________                                                  ._. 
 /  _____/  __ __   ____    ______  ______ __ __  ______    | | 
/   \  ___ |  |  \_/ __ \  /  ___/ /  ___/|  |  \/  ___/    | | 
\    \_\  \|  |  /\  ___/  \___ \  \___ \ |  |  /\___ \      \| 
 \______  /|____/  \___  >/____  >/____  >|____//____  >     __ 
        \/             \/      \/      \/            \/      \/ 
 
");
                Console.WriteLine("Weclome to the guessing game!");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("try to guess the right number! You have {0} tries left!", i);
    
                Console.WriteLine("\nhint: {0}", hint);


                Console.Write("[guess]> ");
                string unparsedGuess = Console.ReadLine();
                var isNumeric = int.TryParse(unparsedGuess, out _);
                
                if (!isNumeric)
                {
                    ExitGame("[!] unknown input!");
                }

                int guess = Convert.ToInt32(Console.ReadLine());

                if (guess != randNum && i == 1)
                {
                    Failure(randNum);
                    break;
                }
                if (guess == randNum)
                {
                    Congrats(randNum);
                    break;

                }
                else if (guess > randNum)
                {
                    hint = "Try smaller!";
                    continue;

                }
                else
                {
                    hint = "Try bigger!";
                    continue;
                }
            }
        }
        static void ExitGame(string message = "Goodbye!")
        {
            Console.Clear();
            Console.WriteLine("Exiting... {0}",message);
            Environment.Exit(0);
        }
        static void PlayAgain()
        {
            Console.Write("\n[play again] (yes/no)>");
            string choice = Console.ReadLine();

            if (choice == "yes") { Game(); } else { ExitGame(); }
        }
    }
}