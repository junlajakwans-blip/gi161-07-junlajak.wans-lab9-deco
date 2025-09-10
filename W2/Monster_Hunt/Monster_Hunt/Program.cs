namespace Monster_Hunt
{
    internal class Program
    {
        static public string playerName;
        static public int playerHealth = 75;
        static public int playerGold = 0;
        static public string[] locations = { "Dark Forest", "Abandoned Mine", "Mystic River", "Cursed Tower", "Dragon's Lair"};
        static public string[] monsters = { "Orc", "Goblin", "Piranha", "Ghost Bird", "Dragon"};
        static public int[] monsterHealths = { 30, 35, 40, 45, 50};
        static public bool[] dungeonCleared = new bool[locations.Length];


        static public int locationChoice;
        static public Random random = new Random();

        static public string[] difficultyLevel = { "Easy", "Normal", "Hard" };
        static public bool[] difficultyCleared = new bool[difficultyLevel.Length];
        static public int difficultyChoice;

        static void Main(string[] args)
        {
            //name
            Console.WriteLine("Welcome Hero to Monster Hunt!");
            Console.Write("Enter you name: ");
            playerName = Console.ReadLine();

            Console.WriteLine("-------------------------------------------");
            //difficulty level
            Console.Write("Choose Difficulty Level: 0-Easy 1-Normal 2-Hard : ");
            while (!int.TryParse(Console.ReadLine(), out difficultyChoice) || difficultyChoice < 0 || difficultyChoice >= difficultyLevel.Length)
            {
                Console.Write("Invalid choice, please enter 0, 1, or 2: ");
            }

            GetPlayerHealthBylevel();

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Hero: {playerName} | Health: {playerHealth} | Gold: {playerGold} \n {difficultyLevel[difficultyChoice]} mode selected : You have {playerHealth} Health.");
            Console.WriteLine($"{locations.Length} Dungeons:");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");

            //Main Game Loop
            int round = 0;

            while (playerHealth > 0 && round < locations.Length)
            {
                // List all locations and their status
                for (int i = 0; i < locations.Length; i++)
                {
                    if (dungeonCleared[i])
                        Console.WriteLine($"({i}). {locations[i]} --> Cleared");
                    else
                        Console.WriteLine($"({i}). {locations[i]}");
                }
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.Write("Choose a dungeon to visit [0 - 4]: ");
                
                // Get and validate user input
                if (!int.TryParse(Console.ReadLine(), out locationChoice) ||
                    locationChoice < 0 || locationChoice >= locations.Length ||
                    dungeonCleared[locationChoice])
                {
                    Console.WriteLine("Invalid input or Dungeon Cleared, Please choose again");
                    continue; // Ask again
                }

                Console.WriteLine($"Dungeon: {locations[locationChoice]}, Monster: {monsters[locationChoice]} appears with {monsterHealths[locationChoice]}");
                Console.WriteLine("-------------------------------------------");

                // Battle Starts
                while (playerHealth > 0 && monsterHealths[locationChoice] > 0)
                {
                    int playerDamage = random.Next(5, 15);
                    int monsterDamage = GetMonstersDamageByDifficulty();

                    monsterHealths[locationChoice] -= playerDamage;
                    playerHealth -= monsterDamage;

                    Console.WriteLine($"You hit the monster for {playerDamage}. " +
                        $"Current Monster HP = {Math.Max(monsterHealths[locationChoice], 0)}");
                    Console.WriteLine($"Monster hit you for {monsterDamage}. Your " +
                        $"Current HP = {Math.Max(playerHealth, 0)}");
                }

                // Conclude the battle
                if (playerHealth > 0)
                {
                    Console.WriteLine("-------------------------------------------");
                    int reward = GetRewardByDifficulty();
                    playerGold += reward;
                    dungeonCleared[locationChoice] = true;
                    round++;
                    Console.WriteLine($"Congratulation {playerName} defeated the monsters {monsters[locationChoice]}! \n You gain +{reward} gold");
                    Console.WriteLine("-------------------------------------------");
                }
                else
                {
                    Console.WriteLine($"You were defeated by the {monsters[locationChoice]}!");
                }
            }
            // Game conclusion
            if (playerHealth > 0) // win
            {
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine("Congratulations! You have cleared all dungeons!");
                Console.WriteLine($"Final Stats - Player: {playerName} | Health: {playerHealth}  \nGold: {playerGold}");
                Console.WriteLine("------------------------------------------------");
            }
            else // defeated
            {
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine($" Game Over {playerName} maybe better luck nex time!");
                Console.WriteLine($"Final Stats - Player: {playerName} | Health: 0  \nGold: You {playerGold} Golds robbed by monsters");
                Console.WriteLine("------------------------------------------------");

            }
        }


        public static void GetPlayerHealthBylevel()
        {
            switch (difficultyChoice)
            {

                case 0: // Easy
                    playerHealth += 30;
                    break;
                case 1: // Normal
                    // No changes for Normal, but you can set default values if needed
                    break;
                case 2: // Hard
                    playerHealth -= 25;
                    break;
                default:
                    Console.WriteLine("Invalid choice, Please choose again.");
                    break;
            }
        }

        static public int GetRewardByDifficulty()
        {
            switch (difficultyChoice)
            {
                case 0: return 15; // Easy
                case 1: return 10; // Normal
                case 2: return 8;  // Hard
                default: return 10; // Default
            }
        }

        static public int GetMonstersDamageByDifficulty()
        {
            double[] multipliers = { 0.8, 1.0, 1.2 };
            int monsterDamageBylevel = random.Next(3, 10);
            double multiplier = 1.0;

            switch (difficultyChoice)
            {
                case 0: multiplier = multipliers[0]; 
                    break; // Easy
                case 1: multiplier = multipliers[1]; 
                    break; // Normal
                case 2: multiplier = multipliers[2]; 
                    break; // Hard
                default: multiplier = multipliers[1]; 
                    break;
            }

            return (int)Math.Round(monsterDamageBylevel * multiplier);
        }


    }
 }

