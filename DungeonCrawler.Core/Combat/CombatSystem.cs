using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Items;
using DungeonCrawler.Core.LootLogic;

namespace DungeonCrawler.Core.Combat
{
    public class CombatSystem
    {
        private readonly LootGenerator lootGenerator;

        public CombatSystem()
        {
            lootGenerator = new LootGenerator();
        }

        public CombatResult Fight(Player player, Enemy enemy)
        {
            while (player.IsAlive() && enemy.IsAlive())
            {
                bool continueFight = PlayerTurn(player, enemy);

                if (!continueFight)
                {
                    return CombatResult.PlayerEscaped;
                }

                if (!enemy.IsAlive())
                {
                    HandleVictory(player, enemy);
                    return CombatResult.PlayerWon;
                }

                AttackResult result = enemy.Attack(player);

                Console.Clear();
                Console.WriteLine(result.Description);
                Console.WriteLine(
                    $"{player.Name} takes {result.Damage} damage.\n");

                if (!player.IsAlive())
                {
                    return CombatResult.EnemyWon;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            return CombatResult.EnemyWon;
        }

        public bool PlayerTurn(Player player, Enemy enemy)
        {
            while (true)
            {
                Console.Clear();
                State(player, enemy);

                string? choice = Console.ReadLine();

                while (choice != "1" &&
                       choice != "2" &&
                       choice != "3")
                {
                    Console.WriteLine("Invalid choice.");
                    choice = Console.ReadLine();
                }

                switch (choice)
                {
                    case "1":
                        AttackResult result = player.Attack(enemy);

                        Console.Clear();
                        Console.WriteLine(result.Description);
                        Console.WriteLine(
                            $"{enemy.Name} takes {result.Damage} damage.\n");

                        Console.WriteLine(
                            "Press any key to continue...");
                        Console.ReadKey();

                        return true;

                    case "2":
                        UseItem(player);
                        break;

                    case "3":
                        return false;
                }
            }
        }

        private void UseItem(Player player)
        {
            Console.Clear();

            Console.WriteLine("Inventory:\n");

            if (player.Inventory.Items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

                return;
            }

            for (int i = 0; i < player.Inventory.Items.Count; i++)
            {
                Item item = player.Inventory.Items[i];

                Console.WriteLine(
                    $"{i + 1}. {item.Name} - {item.Description}");
            }

            Console.WriteLine("\n0. Back");

            string? choice = Console.ReadLine();

            while (true)
            {
                if (choice == "0")
                {
                    return;
                }

                if (int.TryParse(choice, out int index) &&
                    index >= 1 &&
                    index <= player.Inventory.Items.Count)
                {
                    Item selectedItem =
                        player.Inventory.Items[index - 1];

                    int oldHealth = player.Health;
                    int oldAttack = player.AttackPower;
                    int oldDefense = player.Defense;

                    bool used = player.Inventory.UseItem(
                        selectedItem,
                        player);

                    if (used)
                    {
                        Console.Clear();

                        if (selectedItem is Potion)
                        {
                            Console.WriteLine(
                                $"{selectedItem.Name} used.");

                            Console.WriteLine(
                                $"{player.Name}'s HP: " +
                                $"{oldHealth} → {player.Health}");
                        }
                        else if (selectedItem is Weapon weapon)
                        {
                            Console.WriteLine(
                                $"{weapon.Name} equipped!");

                            Console.WriteLine(
                                $"Attack: {oldAttack} → " +
                                $"{player.AttackPower}");
                        }
                        else if (selectedItem is Armor armor)
                        {
                            Console.WriteLine(
                                $"{armor.Name} equipped!");

                            Console.WriteLine(
                                $"Defense: {oldDefense} → " +
                                $"{player.Defense}");
                        }

                        Console.WriteLine(
                            "\nPress any key to continue...");
                        Console.ReadKey();

                        return;
                    }
                }

                Console.WriteLine("Invalid choice.");
                choice = Console.ReadLine();
            }
        }

        private void HandleVictory(Player player, Enemy enemy)
        {
            int previousLevel = player.Level;

            player.GainExperience(enemy.ExperienceReward);
            player.AddGold(enemy.GoldReward);

            Item? loot = lootGenerator.GenerateLoot(enemy);

            Console.Clear();

            Console.WriteLine($"{enemy.Name} defeated!");
            Console.WriteLine($"+{enemy.ExperienceReward} XP");
            Console.WriteLine($"+{enemy.GoldReward} Gold");

            if (loot != null)
            {
                player.Inventory.AddItem(loot);
                Console.WriteLine($"Found: {loot.Name}!");
            }

            if (player.Level > previousLevel)
            {
                Console.WriteLine(
                    $"Level up! You are now level {player.Level}!");
            }

            Console.WriteLine(
                "\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void State(Player player, Enemy enemy)
        {
            Console.WriteLine(
                $"{player.Name}\n" +
                $"HP: {player.Health}/{player.MaxHealth}\n" +
                $"Level: {player.Level}\n" +
                $"XP: {player.Experience}/" +
                $"{player.ExperienceToNextLevel}\n" +
                $"Attack: {player.AttackPower}\n" +
                $"Defense: {player.Defense}\n\n" +
                $"{enemy.Name}\n" +
                $"HP: {enemy.Health}/{enemy.MaxHealth}\n" +
                $"Level: {enemy.Level}\n");

            Console.WriteLine(
                "\n1. Attack\n" +
                "2. Use item\n" +
                "3. Run");

            Console.WriteLine("\nChoose an option: ");
        }
    }
}