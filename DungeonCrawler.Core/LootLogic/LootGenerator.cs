using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Items;

namespace DungeonCrawler.Core.LootLogic
{
    public class LootGenerator
    {
        private readonly Random random = new Random();
        public Item? GenerateLoot(Enemy enemy)
        {
            int roll = random.Next(1, 101);

            if (enemy is Goblin)
            {
                if (roll <= 50)
                {
                    return new Potion(
                        "Small Health Potion",
                        "Restores 20 HP.",
                        20,
                        ItemRarity.Common,
                        15);
                }

                if (roll <= 75)
                {
                    return new Weapon(
                        "Rusty Sword",
                        "An old and worn sword.",
                        7,
                        ItemRarity.Common,
                        30);
                }

                if (roll <= 90)
                {
                    return new Armor(
                        "Leather Armor",
                        "Basic leather protection.",
                        5,
                        ItemRarity.Common,
                        40);
                }

                return null;
            }

            if (enemy is Orc)
            {
                if (roll <= 35)
                {
                    return new Potion(
                        "Large Health Potion",
                        "Restores 50 HP.",
                        50,
                        ItemRarity.Uncommon,
                        30);
                }

                if (roll <= 65)
                {
                    return new Weapon(
                        "Iron Sword",
                        "A strong iron sword.",
                        12,
                        ItemRarity.Uncommon,
                        60);
                }

                if (roll <= 85)
                {
                    return new Armor(
                        "Iron Armor",
                        "Heavy iron armor.",
                        10,
                        ItemRarity.Uncommon,
                        70);
                }

                return null;
            }

            if (enemy is Skeleton)
            {
                if (roll <= 40)
                {
                    return new Potion(
                        "Medium Health Potion",
                        "Restores 35 HP.",
                        35,
                        ItemRarity.Uncommon,
                        25);
                }

                if (roll <= 65)
                {
                    return new Weapon(
                        "Bone Sword",
                        "A sword crafted from the bones of fallen warriors.",
                        10,
                        ItemRarity.Uncommon,
                        50);
                }

                if (roll <= 85)
                {
                    return new Armor(
                        "Bone Armor",
                        "Armor made from hardened bones.",
                        8,
                        ItemRarity.Uncommon,
                        60);
                }

                return null;
            }

            if (enemy is Boss)
            {
                if (roll <= 30)
                {
                    return new Potion(
                        "Greater Health Potion",
                        "Restores 75 HP.",
                        75,
                        ItemRarity.Rare,
                        50);
                }

                if (roll <= 60)
                {
                    return new Weapon(
                        "Demon Sword",
                        "A powerful sword forged for a mighty warrior.",
                        20,
                        ItemRarity.Rare,
                        120);
                }

                if (roll <= 85)
                {
                    return new Armor(
                        "Demon Armor",
                        "Powerful armor that offers excellent protection.",
                        15,
                        ItemRarity.Rare,
                        140);
                }

                if (roll <= 95)
                {
                    return new Weapon(
                        "Legendary Sword",
                        "An extremely powerful legendary weapon.",
                        30,
                        ItemRarity.Legendary,
                        250);
                }
                return null;
            }
            return null;
        }
    }
}
