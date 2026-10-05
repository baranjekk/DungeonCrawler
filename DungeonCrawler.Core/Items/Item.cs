using DungeonCrawler.Core.Characters;

namespace DungeonCrawler.Core.Items
{
    public abstract class Item
    {
        public string Name { get; }
        public string Description { get; }
        public bool IsConsumable { get; }
        public ItemRarity Rarity { get; }
        public int Price {  get; }
        protected Item(string name, string description, bool isConsumable, ItemRarity rarity, int price)
        {
            Name = name;
            Description = description;
            IsConsumable = isConsumable;
            Rarity = rarity;
            Price = price;
        }
        public abstract void Use(Player player);
    }
}
