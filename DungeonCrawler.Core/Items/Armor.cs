using DungeonCrawler.Core.Characters;

namespace DungeonCrawler.Core.Items
{
    public class Armor:Item
    {
        public int Defense { get; }
        public Armor(string name, string description, int defense, ItemRarity rarity, int price) : base(name, description, false, rarity, price)
        {
            Defense = defense;
        }
        public override void Use(Player player)
        {
            player.EquipArmor(this);
        }
    }
}
