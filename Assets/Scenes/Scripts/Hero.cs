class Hero
{
    public string Name;
    public int Health;
    public int Gold;

    public Hero(string newName, int newHealth)
    {
        Name = newName;
        Health = newHealth;
        Gold = 0;
    }

    public void TakeDamage(int dmg)
    {
        Health = System.Math.Max(0, Health - dmg);
    }

    public bool IsAlive() => Health > 0;
}
