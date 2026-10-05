using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Items;

namespace DungeonCrawler.Core
{
    public class DungeonGenerator
    {
        private readonly Random random = new Random();
        public Dungeon Generate(int roomCount)
        {
            Dungeon dungeon = new Dungeon();
            for (int i = 0; i < roomCount - 1; i++)
            {
                Room room = GenerateRoom(i + 1);
                dungeon.AddRoom(room);
            }
            dungeon.AddRoom(new BossRoom(new Boss()));
            return dungeon;
        }
        private Room GenerateRoom(int roomIndex)
        {
            int roomType = random.Next(1, 101);
            return roomType switch
            {
                <= 60 => new CombatRoom(GenerateEnemy(roomIndex)),
                <= 80 => new HealingRoom(30),
                _ => new TreasureRoom(GenerateTreasure())
            };
        }
        private Enemy GenerateEnemy(int roomIndex)
        {
            if (roomIndex <= 2)
            {
                int enemyType = random.Next(1, 3);

                return enemyType switch
                {
                    1 => new Goblin(),
                    2 => new Skeleton(),
                    _ => new Goblin()
                };
            }
            int lateEnemyType = random.Next(1, 3);
            return lateEnemyType switch
            {
                1 => new Skeleton(),
                2 => new Orc(),
                _ => new Skeleton()
            };
        }
        private Item GenerateTreasure()
        {
            int treasureType = random.Next(1, 4);

            return treasureType switch
            {
                1 => new Potion(
                    "Health Potion",
                    "Restores 30 HP.",
                    30,
                    ItemRarity.Common,
                    20),

                2 => new Weapon(
                    "Steel Sword",
                    "A stronger sword.",
                    15,
                    ItemRarity.Uncommon,
                    120),

                3 => new Armor(
                    "Steel Armor",
                    "Better protection.",
                    10,
                    ItemRarity.Uncommon,
                    105),

                _ => new Potion(
                    "Health Potion",
                    "Restores 30 HP.",
                    30,
                    ItemRarity.Common,
                    20)
            };
        }
    }
}
