class Enemy
{
  public string Name { get; set; }
  public int Health { get; set; }
  public int AttackPower { get; set; }

  public Enemy(string name, int health, int attackPower)
  {
    Name = name;
    Health = health;
    AttackPower = attackPower;
  }

  public void Attack(Character player)
  {
    player.TakeDamage(AttackPower);
    Console.WriteLine($"The {Name} strikes you for {AttackPower} damage!");
  }

  public bool IsAlive()
  {
    return Health > 0;
  }
}
