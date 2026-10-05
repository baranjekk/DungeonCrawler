using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Items;

namespace DungeonCrawler.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_StartsWithCorrectStats()
        {
            Player player = new Player("TestPlayer");

            Assert.Equal("TestPlayer", player.Name);
            Assert.Equal(100, player.Health);
            Assert.Equal(100, player.MaxHealth);
            Assert.Equal(25, player.AttackPower);
            Assert.Equal(10, player.Defense);
            Assert.Equal(1, player.Level);
            Assert.Equal(0, player.Experience);
            Assert.Equal(100, player.Gold);
        }

        [Fact]
        public void Player_TakesDamageCorrectly()
        {
            Player player = new Player("TestPlayer");

            int damage = player.TakeDamage(25);

            Assert.Equal(15, damage);
            Assert.Equal(85, player.Health);
        }

        [Fact]
        public void Player_CannotHaveLessThanZeroHealth()
        {
            Player player = new Player("TestPlayer");

            player.TakeDamage(1000);

            Assert.Equal(0, player.Health);
            Assert.False(player.IsAlive());
        }

        [Fact]
        public void Player_HealRestoresHealth()
        {
            Player player = new Player("TestPlayer");

            player.TakeDamage(50);
            player.Heal(30);

            Assert.Equal(90, player.Health);
        }

        [Fact]
        public void Player_HealCannotExceedMaxHealth()
        {
            Player player = new Player("TestPlayer");

            player.TakeDamage(20);
            player.Heal(100);

            Assert.Equal(100, player.Health);
        }

        [Fact]
        public void Player_EquipWeaponIncreasesAttack()
        {
            Player player = new Player("TestPlayer");

            Weapon weapon = new Weapon(
                "Test Sword",
                "Test weapon",
                10,
                ItemRarity.Common,
                50);

            player.Inventory.AddItem(weapon);
            player.EquipWeapon(weapon);

            Assert.Equal(35, player.AttackPower);
            Assert.Equal(weapon, player.EquippedWeapon);
        }

        [Fact]
        public void Player_EquipArmorIncreasesDefense()
        {
            Player player = new Player("TestPlayer");

            Armor armor = new Armor(
                "Test Armor",
                "Test armor",
                5,
                ItemRarity.Common,
                50);

            player.Inventory.AddItem(armor);
            player.EquipArmor(armor);

            Assert.Equal(15, player.Defense);
            Assert.Equal(armor, player.EquippedArmor);
        }

        [Fact]
        public void Player_CannotEquipWeaponNotInInventory()
        {
            Player player = new Player("TestPlayer");

            Weapon weapon = new Weapon(
                "Test Sword",
                "Test weapon",
                10,
                ItemRarity.Common,
                50);

            player.EquipWeapon(weapon);

            Assert.Null(player.EquippedWeapon);
            Assert.Equal(25, player.AttackPower);
        }

        [Fact]
        public void Player_GainsExperienceAndLevelsUp()
        {
            Player player = new Player("TestPlayer");

            player.GainExperience(100);

            Assert.Equal(2, player.Level);
            Assert.Equal(0, player.Experience);
        }

        [Fact]
        public void Player_LevelUpIncreasesStats()
        {
            Player player = new Player("TestPlayer");

            player.GainExperience(100);

            Assert.Equal(110, player.MaxHealth);
            Assert.Equal(110, player.Health);
            Assert.Equal(27, player.BaseAttackPower);
            Assert.Equal(11, player.BaseDefense);
        }

        [Fact]
        public void Player_AddGoldIncreasesGold()
        {
            Player player = new Player("TestPlayer");

            player.AddGold(50);

            Assert.Equal(150, player.Gold);
        }

        [Fact]
        public void Player_SpendGoldWorksCorrectly()
        {
            Player player = new Player("TestPlayer");

            bool result = player.SpendGold(40);

            Assert.True(result);
            Assert.Equal(60, player.Gold);
        }

        [Fact]
        public void Player_CannotSpendMoreGoldThanAvailable()
        {
            Player player = new Player("TestPlayer");

            bool result = player.SpendGold(150);

            Assert.False(result);
            Assert.Equal(100, player.Gold);
        }
    }
}