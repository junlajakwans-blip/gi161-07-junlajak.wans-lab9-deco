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

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Hero to Monster Hunt!");
            Console.Write("Enter you name: ");
            playerName = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Hero: {playerName} | Health: {playerHealth} | Gold: {playerGold}");

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"{locations.Length} Dungeons:");

            for ( int i = 0; i < locations.Length; i++)
            {
                Console.WriteLine($"({i}). {locations[i]}");
            }

            //Main Game Loop
            int round = 0;

            while (playerHealth > 0 && round < locations.Length)
            {
                Console.Write("Choose a dungeon to visit [0 - 4]: ");
                locationChoice = int.Parse(Console.ReadLine());

                if (locationChoice >= 0 && locationChoice < locations.Length && !dungeonCleared[locationChoice])
                {
                    Console.WriteLine($"Dungeon: {locations[locationChoice]}, Monster: {monsters[locationChoice]} appears with {monsterHealths[locationChoice]}");
                    Console.WriteLine("-------------------------------------------");
                    //Battle Starts
                    while (playerHealth > 0 && monsterHealths[locationChoice] > 0)
                    {
                        int playerDamage = random.Next(5, 15);
                        int monsterDamage = random.Next(3, 10);

                        //Player Attack Monster
                        monsterHealths[locationChoice] -= playerDamage;

                        //Monster Attack Player
                        playerHealth -= monsterDamage;

                        Console.WriteLine($"You hit the monster for {playerDamage}. " +
                            $"Current Monster HP = {Math.Max(monsterHealths[locationChoice], 0)}");

                        Console.WriteLine($"Monster hit you for {monsterDamage}. Your " +
                            $"Current HP = {Math.Max(playerHealth, 0)}");

                    }

                    //Conclude the battle
                    if (playerHealth > 0)
                    {
                        Console.WriteLine("You defeated the monster! +10 gold.");
                        playerGold += 10;
                    }
                    else
                    {
                        Console.WriteLine("You were defeated by the monster!");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input or Dungeon Cleared, Please choose again");
                }

                

           
            }

        }
    }
}
