using DungeonCrawler.Core.Characters;

namespace DungeonCrawler.Core.Items
{
    public class Weapon:Item
    {
        public int Damage { get; }
        public Weapon(string name, string description, int damage, ItemRarity rarity, int price):base(name, description, false, rarity, price)
        {
            Damage = damage;
        }
        public override void Use(Player player)
        {
            player.EquipWeapon(this);
        }
    }
}
