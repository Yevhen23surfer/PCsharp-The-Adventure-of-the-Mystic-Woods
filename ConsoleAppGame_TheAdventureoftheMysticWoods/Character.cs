class Character
{
  public string Name { get; set; }
  public int Health { get; set; }
  public int Inventory { get; set; } // Added for storing items

  public Character(string name)
  {
    Name = name;
    Health = 100;
    Inventory = 0; // Starts with no items
  }

  public void TakeDamage(int damage)
  {
    Health -= damage;
    if (Health < 0) Health = 0;
  }

  public void Rest()
  {
    Health += 20;
    if (Health > 100) Health = 100;
  }

  public void AddItem(string item) // Added to manage inventory
  {
    Inventory++;
    Console.WriteLine($"You found a {item}! Added to your inventory.");
  }
}
