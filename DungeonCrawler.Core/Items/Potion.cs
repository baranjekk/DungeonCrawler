using DungeonCrawler.Core.Characters;

namespace DungeonCrawler.Core.Items
{
    public class Potion:Item
    {
        public int HealAmount { get; }
        public Potion(string name, string description, int healAmount, ItemRarity rarity, int price):base(name, description, true, rarity, price)
        {
            HealAmount = healAmount;
        }
        public override void Use(Player player)
        {
            player.Heal(HealAmount);
        }
    }
}
