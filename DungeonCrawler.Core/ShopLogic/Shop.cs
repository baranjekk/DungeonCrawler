using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Items;

namespace DungeonCrawler.Core.ShopLogic
{
    public class Shop
    {
        private readonly List<Item> items;
        public Shop()
        {
            items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void ShowBuyMenu()
        {
            Console.WriteLine("=== BUY ITEMS ===\n");

            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];

                if (item is Weapon weapon)
                {
                    Console.WriteLine(
                        $"{i + 1}. {weapon.Name} [{weapon.Rarity}] " +
                        $"(+{weapon.Damage} Attack) - {weapon.Price} Gold");
                }
                else if (item is Armor armor)
                {
                    Console.WriteLine(
                        $"{i + 1}. {armor.Name} [{armor.Rarity}] " +
                        $"(+{armor.Defense} Defense) - {armor.Price} Gold");
                }
                else
                {
                    Console.WriteLine(
                        $"{i + 1}. {item.Name} [{item.Rarity}] " +
                        $"- {item.Price} Gold");
                }
            }
            Console.WriteLine("\n0. Back");
        }
        public bool BuyItem(Player player, int index)
        {
            if (index < 0 || index >= items.Count)
            {
                return false;
            }
            Item item = items[index];
            if (!player.SpendGold(item.Price))
            {
                return false;
            }
            player.Inventory.AddItem(item);
            items.RemoveAt(index);
            return true;
        }
        public int GetItemCount()
        {
            return items.Count;
        }
        public bool SellItem(Player player, int index)
        {
            IReadOnlyList<Item> inventoryItems =
                player.Inventory.GetItems();
            if (index < 0 || index >= inventoryItems.Count)
            {
                return false;
            }
            Item item = inventoryItems[index];
            int sellPrice = item.Price / 2;
            player.Inventory.RemoveItem(item);
            player.AddGold(sellPrice);
            return true;
        }
        public void ShowSellMenu(Player player)
        {
            Console.WriteLine("=== SELL ITEMS ===\n");
            IReadOnlyList<Item> inventoryItems =
                player.Inventory.GetItems();
            if (inventoryItems.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
                return;
            }
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                int sellPrice =
                    inventoryItems[i].Price / 2;
                Console.WriteLine(
                    $"{i + 1}. {inventoryItems[i].Name} - " +
                    $"{sellPrice} Gold");
            }
            Console.WriteLine("\n0. Back");
        }
    }
}