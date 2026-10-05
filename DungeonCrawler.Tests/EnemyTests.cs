using DungeonCrawler.Core.Characters;

namespace DungeonCrawler.Tests
{
    public class EnemyTests
    {
        [Fact]
        public void Goblin_HasCorrectStats()
        {
            Goblin goblin = new Goblin();

            Assert.Equal("Goblin", goblin.Name);
            Assert.Equal(50, goblin.Health);
            Assert.Equal(50, goblin.MaxHealth);
            Assert.Equal(15, goblin.AttackPower);
            Assert.Equal(5, goblin.Defense);
            Assert.Equal(1, goblin.Level);
            Assert.Equal(25, goblin.ExperienceReward);
            Assert.Equal(15, goblin.GoldReward);
        }

        [Fact]
        public void Skeleton_HasCorrectStats()
        {
            Skeleton skeleton = new Skeleton();

            Assert.Equal("Skeleton", skeleton.Name);
            Assert.Equal(60, skeleton.Health);
            Assert.Equal(60, skeleton.MaxHealth);
            Assert.Equal(18, skeleton.AttackPower);
            Assert.Equal(7, skeleton.Defense);
            Assert.Equal(2, skeleton.Level);
            Assert.Equal(40, skeleton.ExperienceReward);
            Assert.Equal(25, skeleton.GoldReward);
        }

        [Fact]
        public void Orc_HasCorrectStats()
        {
            Orc orc = new Orc();

            Assert.Equal("Orc", orc.Name);
            Assert.Equal(100, orc.Health);
            Assert.Equal(100, orc.MaxHealth);
            Assert.Equal(25, orc.AttackPower);
            Assert.Equal(10, orc.Defense);
            Assert.Equal(3, orc.Level);
            Assert.Equal(75, orc.ExperienceReward);
            Assert.Equal(40, orc.GoldReward);
        }

        [Fact]
        public void Boss_HasCorrectStats()
        {
            Boss boss = new Boss();

            Assert.Equal("Dungeon Boss", boss.Name);
            Assert.Equal(150, boss.Health);
            Assert.Equal(150, boss.MaxHealth);
            Assert.Equal(30, boss.AttackPower);
            Assert.Equal(15, boss.Defense);
            Assert.Equal(5, boss.Level);
            Assert.Equal(150, boss.ExperienceReward);
            Assert.Equal(80, boss.GoldReward);
        }

        [Fact]
        public void Goblin_IsAnEnemy()
        {
            Goblin goblin = new Goblin();

            Assert.IsAssignableFrom<Enemy>(goblin);
        }

        [Fact]
        public void Skeleton_IsAnEnemy()
        {
            Skeleton skeleton = new Skeleton();

            Assert.IsAssignableFrom<Enemy>(skeleton);
        }

        [Fact]
        public void Orc_IsAnEnemy()
        {
            Orc orc = new Orc();

            Assert.IsAssignableFrom<Enemy>(orc);
        }

        [Fact]
        public void Boss_IsAnEnemy()
        {
            Boss boss = new Boss();

            Assert.IsAssignableFrom<Enemy>(boss);
        }
    }
}