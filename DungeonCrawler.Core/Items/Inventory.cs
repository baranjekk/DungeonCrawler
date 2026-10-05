using DungeonCrawler.Core.Characters;

namespace DungeonCrawler.Core.Items
{
    public class Inventory
    {
        private readonly List<Item> items = new();
        public IReadOnlyList<Item> Items => items;
        public Inventory() { }
        public Inventory(List<Item> items) { this.items = new List<Item>(items); }
        public void AddItem(Item item) { items.Add(item); }
        public void RemoveItem(Item item) { items.Remove(item); }
        public bool UseItem(Item item, Player player)
        {
            if (!items.Contains(item))
            {
                return false;
            }
            item.Use(player);
            if (item.IsConsumable)
                items.Remove(item);
            return true;
        }
        public IReadOnlyList<Item> GetItems()
        {
            return items;
        }
    }
}
