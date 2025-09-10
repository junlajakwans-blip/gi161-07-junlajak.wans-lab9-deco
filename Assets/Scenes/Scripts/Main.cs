using UnityEngine;

public class Main : MonoBehaviour
{
    static string[] locations = { "Dark Forest", "Abandoned Mine", "Mystic River", "Cursed Tower", "Dragon's Lair" };

    void Start()
    {
        Hero hero = new Hero("Poro", 75);
        Debug.Log($"Hero: {hero.Name}, HP: {hero.Health}, Gold: {hero.Gold}");

        for (int i = 0; i < locations.Length; i++)
        {
            Monster monster = null;

            switch (i)
            {
                case 0: monster = new Orc(); break;
                case 1: monster = new Goblin(); break;
                case 2: monster = new Piranha(); break;
                case 3: monster = new GhostBird(); break;
                case 4: monster = new Dragon(); break;
            }

            if (monster != null)
            {
                Debug.Log($"Location: {locations[i]}, Monster: {monster.Name}, HP: {monster.Health}");
            }
        }
    }
}
