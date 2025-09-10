class Monster
{
    public string Name;
    public int Health;

    public Monster(string newName, int newHealth)
    {
        Name = newName;
        Health = newHealth;
    }

    public void TakeDamage(int dmg)
    {
        Health = System.Math.Max(0, Health - dmg);
    }

    public bool IsAlive() => Health > 0;
}

// ===== Subclasses =====

class Orc : Monster
{
    public Orc() : base("Orc", 30) { }
}

class Goblin : Monster
{
    public Goblin() : base("Goblin", 35) { }
}

class Piranha : Monster
{
    public Piranha() : base("Piranha", 40) { }
}

class GhostBird : Monster
{
    public GhostBird() : base("Ghost Bird", 45) { }
}

class Dragon : Monster
{
    public Dragon() : base("Dragon", 50) { }
}
