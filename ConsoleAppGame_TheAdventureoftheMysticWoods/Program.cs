Console.WriteLine("Welcome to the Adventure of the Mystic Woods!");

// Initialize character and start the game
Console.Write("Enter your character's name: ");
string name = Console.ReadLine();
Character player = new Character(name);

StartGame(player); // Call the main game loop function

static void StartGame(Character player)
{
  Console.WriteLine($"\nGreetings, {player.Name}. The whispers of a legendary treasure hidden deep within the Mystic Woods have lured you here. Are you brave enough to face the unknown?");
  Console.WriteLine("[1] Enter the Woods  [2] Turn Back");

  string choice = Console.ReadLine();

  switch (choice)
  {
    case "1":
      ForestPath(player); // Enter the forest with a new function
      break;
    case "2":
      Console.WriteLine("Fear grips your heart, and you decide to return home. The legend of the treasure remains a mystery.");
      break;
    default:
      Console.WriteLine("Invalid choice. Please try again.");
      StartGame(player); // Restart the starting prompt
      break;
  }
}


// Include Enemy class definition

static void ForestPath(Character player)
{
  // ... (existing code)

  if (EncounterEnemy()) // Check for random encounter
  {
    Enemy enemy = GenerateEnemy(); // Create a random enemy
    Console.WriteLine($"A wild {enemy.Name} appears!");
    Battle(player, enemy); // Start combat encounter
  }
  else
  {
    // Continue with path choices if no encounter
  }
}

static bool EncounterEnemy()
{
  // Simulate a 30% chance of encountering an enemy (modify percentages as needed)
  Random random = new Random();
  return random.Next(1, 11) <= 3; // Returns true if random number between 1-10 is less than or equal to 3
}

static Enemy GenerateEnemy()
{
  // Define different enemy types with varying stats (name, health, attack power)
  // Randomly choose one and return the enemy object

  Enemy enemy1 = new Enemy("Goblin", 30, 10);
  Enemy enemy2 = new Enemy("Giant Spider", 50, 15);

  int randomEnemy = new Random().Next(1, 3); // Random number between 1 and 2

  switch (randomEnemy)
  {
    case 1:
      return enemy1;
    case 2:
      return enemy2;
    default:
      return null; // Shouldn't happen, but handle potential errors
  }
}

static void Battle(Character player, Enemy enemy)
{
  while (player.Health > 0 && enemy.IsAlive()) // Fight loop until someone dies
  {
    Console.WriteLine("[1] Attack  [2] Run Away");
    string choice = Console.ReadLine();

    switch (choice)
    {
      case "1":
        enemy.Attack(player); // Enemy attacks first
        if (enemy.IsAlive()) // Check if enemy survives player attack
        {
          player.TakeDamage(enemy.AttackPower);
          Console.WriteLine($"The {enemy.Name} retaliates for {enemy.AttackPower} damage!");
        }
        break;
      case "2":
        // Implement logic for running away (success chance, health cost, etc.)
        Console.WriteLine("You attempt to flee!");
        // ... (Implement escape logic here)
        break;
      default:
        Console.WriteLine("Invalid choice. Please try again.");
        break;
    }

    if (!enemy.IsAlive()) // Check if enemy is defeated
    {
      Console.WriteLine($"You defeated the {enemy.Name}!");
      // Add experience points, loot drops, etc. (optional)
    }
  }

  if (player.Health <= 0) // Check for player death
  {
    Console.WriteLine("You have succumbed to your wounds. Game Over.");
    // End game or allow restart from a checkpoint (optional)
  }
}
