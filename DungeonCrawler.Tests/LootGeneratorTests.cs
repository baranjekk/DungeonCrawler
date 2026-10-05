using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Items;
using DungeonCrawler.Core.LootLogic;

namespace DungeonCrawler.Tests
{
    public class LootGeneratorTests
    {
        [Fact]
        public void LootGenerator_GoblinLootIsValid()
        {
            LootGenerator generator = new LootGenerator();
            Goblin goblin = new Goblin();

            for (int i = 0; i < 100; i++)
            {
                Item? loot = generator.GenerateLoot(goblin);

                if (loot == null)
                    continue;

                Assert.True(
                    loot is Potion ||
                    loot is Weapon ||
                    loot is Armor);
            }
        }

        [Fact]
        public void LootGenerator_SkeletonLootIsValid()
        {
            LootGenerator generator = new LootGenerator();
            Skeleton skeleton = new Skeleton();

            for (int i = 0; i < 100; i++)
            {
                Item? loot = generator.GenerateLoot(skeleton);

                if (loot == null)
                    continue;

                Assert.True(
                    loot is Potion ||
                    loot is Weapon ||
                    loot is Armor);
            }
        }

        [Fact]
        public void LootGenerator_OrcLootIsValid()
        {
            LootGenerator generator = new LootGenerator();
            Orc orc = new Orc();

            for (int i = 0; i < 100; i++)
            {
                Item? loot = generator.GenerateLoot(orc);

                if (loot == null)
                    continue;

                Assert.True(
                    loot is Potion ||
                    loot is Weapon ||
                    loot is Armor);
            }
        }

        [Fact]
        public void LootGenerator_BossLootIsValid()
        {
            LootGenerator generator = new LootGenerator();
            Boss boss = new Boss();

            for (int i = 0; i < 100; i++)
            {
                Item? loot = generator.GenerateLoot(boss);

                if (loot == null)
                    continue;

                Assert.True(
                    loot is Potion ||
                    loot is Weapon ||
                    loot is Armor);
            }
        }

        [Fact]
        public void LootGenerator_BossCanDropLegendarySword()
        {
            LootGenerator generator = new LootGenerator();
            Boss boss = new Boss();

            bool legendaryFound = false;

            for (int i = 0; i < 1000; i++)
            {
                Item? loot = generator.GenerateLoot(boss);

                if (loot is Weapon weapon &&
                    weapon.Name == "Legendary Sword")
                {
                    legendaryFound = true;
                    break;
                }
            }

            Assert.True(legendaryFound);
        }
    }
}