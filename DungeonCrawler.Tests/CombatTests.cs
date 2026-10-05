using DungeonCrawler.Core.Characters;

namespace DungeonCrawler.Tests
{
    public class CombatTests
    {
        [Fact]
        public void Player_AttackDealsCorrectDamage()
        {
            Player player = new Player("Player");
            Goblin goblin = new Goblin();

            int oldHealth = goblin.Health;

            var result = player.Attack(goblin);

            Assert.Equal(20, result.Damage);
            Assert.Equal(oldHealth - 20, goblin.Health);
        }

        [Fact]
        public void Enemy_AttackDealsCorrectDamage()
        {
            Player player = new Player("Player");
            Enemy enemy = new Enemy(
                "Test Enemy",
                100,
                100,
                20,
                5,
                1,
                20,
                10);

            var result = enemy.Attack(player);

            Assert.Equal(10, result.Damage);
            Assert.Equal(90, player.Health);
        }

        [Fact]
        public void AttackResult_ContainsCorrectInformation()
        {
            Player player = new Player("Player");
            Enemy enemy = new Enemy(
                "Test Enemy",
                100,
                100,
                20,
                5,
                1,
                20,
                10);

            var result = player.Attack(enemy);

            Assert.Equal(20, result.Damage);
            Assert.False(result.IsSpecialAttack);
            Assert.Equal(
                "Player performs a normal attack.",
                result.Description);
        }

        [Fact]
        public void Enemy_CanBeDefeated()
        {
            Player player = new Player("Player");

            Enemy enemy = new Enemy(
                "Weak Enemy",
                10,
                10,
                1,
                0,
                1,
                10,
                5);

            player.Attack(enemy);

            Assert.Equal(0, enemy.Health);
            Assert.False(enemy.IsAlive());
        }

        [Fact]
        public void DefeatedEnemy_CannotHaveNegativeHealth()
        {
            Player player = new Player("Player");

            Enemy enemy = new Enemy(
                "Weak Enemy",
                10,
                10,
                1,
                0,
                1,
                10,
                5);

            player.Attack(enemy);
            player.Attack(enemy);

            Assert.Equal(0, enemy.Health);
        }

        [Fact]
        public void Enemy_HasCorrectExperienceAndGoldReward()
        {
            Enemy enemy = new Enemy(
                "Test Enemy",
                100,
                100,
                20,
                5,
                1,
                50,
                25);

            Assert.Equal(50, enemy.ExperienceReward);
            Assert.Equal(25, enemy.GoldReward);
        }
    }
}