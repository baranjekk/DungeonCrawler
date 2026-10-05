using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Combat;
using DungeonCrawler.Core.Items;
using DungeonCrawler.Core.ShopLogic;
using DungeonCrawler.Core.SaveLogic;

namespace DungeonCrawler.Core.Game
{
    public class Game
    {
        private Player player;
        private readonly CombatSystem combatSystem;
        private readonly DungeonGenerator dungeonGenerator;
        private readonly Shop shop;
        private readonly SaveSystem saveSystem;
        public Game()
        {
            combatSystem = new CombatSystem();
            dungeonGenerator = new DungeonGenerator();
            shop = new Shop();
            saveSystem = new SaveSystem();
            InitializePlayer();
            InitializeShop();
        }
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("=== DUNGEON CRAWLER ===");
            Console.WriteLine($"\nWelcome, {player.Name}!");
            Console.WriteLine("\nPress any key to start...");
            Console.ReadKey();
            MainMenu();
        }

        private void InitializePlayer()
        {
            Console.Clear();
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Name cannot be empty. Enter your name: ");
                name = Console.ReadLine();
            }
            player = new Player(name);
        }
        private void InitializeShop()
        {
            shop.AddItem(new Potion(
                "Health Potion",
                "Restores 30 HP.",
                30,
                ItemRarity.Common,
                20));

            shop.AddItem(new Weapon(
                "Iron Sword",
                "A simple iron sword.",
                10,
                ItemRarity.Common,
                75));

            shop.AddItem(new Armor(
                "Leather Armor",
                "Basic leather protection.",
                3,
                ItemRarity.Common,
                40));
        }
        private void MainMenu()
        {
            bool running = true;
            while(running)
            {
                Console.Clear();
                Console.WriteLine("=== DUNGEON CRAWLER ===\n");
                Console.WriteLine
                    ("1. Explore\n" +
                    "2. Inventory\n" +
                    "3. Player Stats\n" +
                    "4. Shop\n" +
                    "5. Save Game\n" +
                    "6. Load Game\n" +
                    "7. Exit\n\n" +
                    "Choose an option:\n");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        StartDungeon();
                        break;
                    case "2":
                        ShowInventory();
                        break;
                    case "3":
                        ShowStats();
                        break;
                    case "4":
                        OpenShop();
                        break;
                    case "5":
                        SaveGame();
                        break;

                    case "6":
                        LoadGame();
                        break;

                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.\n");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("=== PLAYER STATS ===\n");
            Console.WriteLine(
                $"{player.Name}\n" +
                $"HP: {player.Health}/{player.MaxHealth}\n" +
                $"Level: {player.Level}\n" +
                $"XP: {player.Experience}/{player.ExperienceToNextLevel}\n" +
                $"Gold: {player.Gold}\n" +
                $"Attack: {player.AttackPower}\n" +
                $"Defense: {player.Defense}\n" +
                $"\nWeapon: {player.EquippedWeapon?.Name ?? "None"}\n" +
                $"Armor: {player.EquippedArmor?.Name ?? "None"}");
            Console.WriteLine();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void ShowInventory()
        {
            bool open = true;
            while (open)
            {
                Console.Clear();
                Console.WriteLine("=== INVENTORY ===\n");
                if (player.Inventory.Items.Count == 0)
                {
                    Console.WriteLine("Inventory is empty.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    return;
                }
                for (int i = 0; i < player.Inventory.Items.Count; i++)
                {
                    Item item = player.Inventory.Items[i];
                    if (item is Weapon weapon)
                    {
                        string equipped = player.EquippedWeapon == weapon
                            ? " [EQUIPPED]"
                            : "";

                        Console.WriteLine(
                            $"{i + 1}. {weapon.Name} [{weapon.Rarity}] " +
                            $"(+{weapon.Damage} Attack){equipped}");
                    }
                    else if (item is Armor armor)
                    {
                        string equipped = player.EquippedArmor == armor
                            ? " [EQUIPPED]"
                            : "";

                        Console.WriteLine(
                            $"{i + 1}. {armor.Name} [{armor.Rarity}] " +
                            $"(+{armor.Defense} Defense){equipped}");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"{i + 1}. {item.Name} [{item.Rarity}] - {item.Description}");
                    }
                }
                Console.WriteLine("\n0. Back");
                Console.Write("\nChoose an item: ");
                string choice = Console.ReadLine();
                if (choice == "0")
                {
                    open = false;
                    continue;
                }
                if (!int.TryParse(choice, out int index) ||
                    index < 1 ||
                    index > player.Inventory.Items.Count)
                {
                    Console.WriteLine("\nInvalid choice.");
                    Console.ReadKey();
                    continue;
                }

                Item selectedItem =
                    player.Inventory.Items[index - 1];

                ShowItemMenu(selectedItem);
            }
        }
        private void ShowItemMenu(Item item)
        {
            Console.Clear();
            Console.WriteLine("=== ITEM ===\n");
            Console.WriteLine($"Name: {item.Name}");
            Console.WriteLine($"Rarity: {item.Rarity}");
            Console.WriteLine($"Description: {item.Description}");
            Console.WriteLine();
            if (item.IsConsumable)
            {
                Console.WriteLine("1. Use");
            }
            else
            {
                if (item is Weapon)
                {
                    if (item == player.EquippedWeapon)
                        Console.WriteLine("1. Unequip");
                    else
                        Console.WriteLine("1. Equip");
                }
                else if (item is Armor)
                {
                    if (item == player.EquippedArmor)
                        Console.WriteLine("1. Unequip");
                    else
                        Console.WriteLine("1. Equip");
                }
            }
            Console.WriteLine("2. Back");
            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();
            if (choice != "1")
                return;
            if (item.IsConsumable)
            {
                bool used = player.Inventory.UseItem(item, player);
                if (used)
                    Console.WriteLine($"\nYou used {item.Name}.");
            }
            else if (item is Weapon weapon)
            {
                if (item == player.EquippedWeapon)
                {
                    player.UnequipWeapon();
                    Console.WriteLine($"\nYou unequipped {weapon.Name}.");
                }
                else
                {
                    player.EquipWeapon(weapon);
                    Console.WriteLine($"\nYou equipped {weapon.Name}.");
                }
            }
            else if (item is Armor armor)
            {
                if (item == player.EquippedArmor)
                {
                    player.UnequipArmor();
                    Console.WriteLine($"\nYou unequipped {armor.Name}.");
                }
                else
                {
                    player.EquipArmor(armor);
                    Console.WriteLine($"\nYou equipped {armor.Name}.");
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void StartDungeon()
        {
            Dungeon dungeon = dungeonGenerator.Generate(5);
            while (true)
            {
                Room room = dungeon.CurrentRoom;
                Console.Clear();
                Console.WriteLine(
                    $"=== ROOM {dungeon.CurrentRoomIndex + 1}/" +
                    $"{dungeon.Rooms.Count} ===\n");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                room.Enter(player, combatSystem);
                if (!player.IsAlive())
                {
                    GameOver();
                    return;
                }
                if (!room.IsCleared)
                    return;
                if (!dungeon.MoveToNextRoom())
                {
                    Console.Clear();
                    Console.WriteLine("=== DUNGEON CLEARED ===");
                    Console.WriteLine("\nCongratulations! You defeated all enemies.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    return;
                }
            }
        }
        private void OpenShop()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SHOP ===");
                Console.WriteLine($"\nGold: {player.Gold}");
                Console.WriteLine("\n1. Buy Items" +
                "\n2. Sell Items" +
                "\n3. Leave Shop");
                Console.Write("\nChoose an option: ");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        BuyFromShop();
                        break;

                    case "2":
                        SellToShop();
                        break;

                    case "3":
                        return;
                }
            }
        }
        private void BuyFromShop()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine($"Gold: {player.Gold}\n");
                shop.ShowBuyMenu();
                Console.Write("\nChoose an item: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                    continue;
                if (choice == 0)
                    return;
                if (shop.BuyItem(player, choice - 1))
                    Console.WriteLine("\nItem purchased!");
                else
                    Console.WriteLine("\nYou don't have enough Gold!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        private void SellToShop()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Gold: {player.Gold}\n");
                shop.ShowSellMenu(player);
                var items = player.Inventory.GetItems();
                if (items.Count == 0)
                {
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey();
                    return;
                }
                Console.Write("\nChoose an item: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                    continue;
                if (choice == 0)
                    return;
                if (shop.SellItem(player, choice - 1))
                {
                    Console.WriteLine("\nItem sold!");
                }
                else
                {
                    Console.WriteLine("\nInvalid choice!");
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        private void GameOver()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GAME OVER ===");
                Console.WriteLine();
                Console.WriteLine($"{player.Name} has been defeated.");
                Console.WriteLine();
                Console.WriteLine("1. Play Again");
                Console.WriteLine("2. Exit");
                Console.WriteLine("\nChoose an option: ");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        InitializePlayer();
                        Start();
                        return;

                    case "2":
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void SaveGame()
        {
            saveSystem.SaveGame(player);
            Console.Clear();
            Console.WriteLine("=== SAVE GAME ===");
            Console.WriteLine("\nGame saved successfully!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void LoadGame()
        {
            Player? loadedPlayer = saveSystem.LoadGame();
            Console.Clear();
            Console.WriteLine("=== LOAD GAME ===\n");
            if (loadedPlayer == null)
            {
                Console.WriteLine("No save file found.\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            player = loadedPlayer;
            Console.WriteLine("Game loaded successfully!\n");
            Console.WriteLine($"Welcome back, {player.Name}!");
            Console.WriteLine($"Level: {player.Level}");
            Console.WriteLine($"Gold: {player.Gold}\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
