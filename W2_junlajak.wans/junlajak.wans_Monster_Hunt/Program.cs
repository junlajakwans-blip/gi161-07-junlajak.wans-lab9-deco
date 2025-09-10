namespace Monster_Hunt
{

   internal class Program
   {

        static public string playerName; // input player name
        static public int playerHealth = 150; // initial player health
        static public int playerGold = 0; // initial player gold

        // Locations adn Monsters:
        static public string[] locations = { "Dark Forest", "Abandoned Mine", "Mythic River", "Cursed Tower", "Dragon's Lair" }; // locations
        static public int locationChoice; // player location choice 

        static public string[] monsters = { "Slime", "Wolf", "Siren", "Dark Wizard", "Sylrin" }; // names of monsters
        static public int[] monsterHealths = { 30, 35, 40, 45, 50 }; // health of monsters arrange by locations and monsters
        static public int[] monsterGold = { 10, 20, 30, 40, 50 }; // gold rewarded for defeating monsters
        static public bool[] DungeousCleared = new bool[locations.Length]; // track cleared locations

        static Random random = new Random(); // random number Monster Damage and Player Damage

        static public void Main(string[] args)
        {
            // Game introduction
            Console.WriteLine("Welcome to Monster Hunt!");
            Console.Write("Enter your player name: ");
            playerName = Console.ReadLine();

            // Initialize DungeousCleared array to false
            int round = 0;
            // Game loop

            while (playerHealth > 0 && round < locations.Length)
            {
                // Display current player stats and locations
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Hello, {playerName}| Health: {playerHealth} | Gold: {playerGold}");

                Console.WriteLine($"{locations.Length} Dungeous:");

                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");

                // List all locations
                for (int i = 0; i < locations.Length; i++)
                {
                    if (DungeousCleared[i])
                    {
                        Console.WriteLine($"({i}). {locations[i]} --> Cleared");
                    }
                    else
                    {
                        Console.WriteLine($"({i}). {locations[i]}");
                    }
                }
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");

                // Player chooses a location input number [0-4]
                Console.WriteLine("Choose a dungeon to visit [0-4]: ");
                locationChoice = int.Parse(Console.ReadLine());

                if (locationChoice >= 0 && locationChoice < locations.Length && !DungeousCleared[locationChoice]) // check valid input and if dungeon is already cleared [True]
                {

                        Console.WriteLine($"Dungeon: {locations[locationChoice]}, Monster: {monsters[locationChoice]} appears with: {monsterHealths[locationChoice]}");
                        Console.WriteLine("------------------------------------------------");

                  //still fighting
                        while (playerHealth > 0 && monsterHealths[locationChoice] > 0)
                        {
                            // Calculate random damage for both player and monster
                            int playerDamage = random.Next(5, 15);
                            int monsterDamage = random.Next(3, 10);

                            // Exchange damage
                            monsterHealths[locationChoice] -= playerDamage;

                            playerHealth -= monsterDamage;

                            // Display current health after each exchange
                            Console.WriteLine($"{playerName} hit {monsters[locationChoice]} for {playerDamage} damage. " +
                                $"Current Monster HP = {Math.Max(monsterHealths[locationChoice], 0)}");

                            Console.WriteLine($"{monsters[locationChoice]} hit {playerName} for {monsterDamage} damage. " +
                                $"Current Player HP = {Math.Max(playerHealth, 0)}");
                        }

                    
 
                    // end of fight
                    if (playerHealth > 0) //still alive
                    {
                        Console.WriteLine($"You have defeated the {monsters[locationChoice]}!"); // win message
                        playerGold += monsterGold[locationChoice];
                        DungeousCleared[locationChoice] = true; // mark dungeon as cleared
                        round++; // count cleared dungeous
                        Console.WriteLine($"You earned {monsterGold[locationChoice]} gold. Total Gold: {playerGold}"); //display gold earned
                    }
                    else // defeated by monster
                    {
                        Console.WriteLine($"You have been defeated by {monsters[locationChoice]}! Game Over.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input or dungeon already Cleared Please choose again.");
                }
            }

            // Game conclusion
            if (playerHealth > 0) // win
            {
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine("Congratulations! You have cleared all dungeons!");
                Console.WriteLine($"Final Stats - Player: {playerName} | Health: {playerHealth} | Gold: {playerGold}");
                Console.WriteLine("------------------------------------------------");
            }
            else // defeated
            {
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine($"Final Stats - Player: {playerName} | Health: 0 | Gold: You {playerGold} Golds robbed by monsters");
                Console.WriteLine("------------------------------------------------");
            }

        }
    }
}
