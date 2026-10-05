using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Items;

namespace DungeonCrawler.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void Inventory_AddItemAddsItem()
        {
            Player player = new Player("TestPlayer");

            Potion potion = new Potion(
                "Health Potion",
                "Restores 30 HP.",
                30,
                ItemRarity.Common,
                20);

            player.Inventory.AddItem(potion);

            Assert.Single(player.Inventory.Items);
            Assert.Contains(potion, player.Inventory.Items);
        }

        [Fact]
        public void Inventory_RemoveItemRemovesItem()
        {
            Player player = new Player("TestPlayer");

            Potion potion = new Potion(
                "Health Potion",
                "Restores 30 HP.",
                30,
                ItemRarity.Common,
                20);

            player.Inventory.AddItem(potion);
            player.Inventory.RemoveItem(potion);

            Assert.Empty(player.Inventory.Items);
        }

        [Fact]
        public void Inventory_UsePotionHealsPlayer()
        {
            Player player = new Player("TestPlayer");

            player.TakeDamage(50);

            Potion potion = new Potion(
                "Health Potion",
                "Restores 30 HP.",
                30,
                ItemRarity.Common,
                20);

            player.Inventory.AddItem(potion);

            bool result =
                player.Inventory.UseItem(potion, player);

            Assert.True(result);
            Assert.Equal(90, player.Health);
        }

        [Fact]
        public void Inventory_UsedPotionIsRemoved()
        {
            Player player = new Player("TestPlayer");

            Potion potion = new Potion(
                "Health Potion",
                "Restores 30 HP.",
                30,
                ItemRarity.Common,
                20);

            player.Inventory.AddItem(potion);

            player.Inventory.UseItem(potion, player);

            Assert.Empty(player.Inventory.Items);
        }

        [Fact]
        public void Inventory_EquippedWeaponRemainsInInventory()
        {
            Player player = new Player("TestPlayer");

            Weapon weapon = new Weapon(
                "Iron Sword",
                "A simple sword.",
                10,
                ItemRarity.Common,
                75);

            player.Inventory.AddItem(weapon);

            player.Inventory.UseItem(weapon, player);

            Assert.Contains(weapon, player.Inventory.Items);
            Assert.Equal(weapon, player.EquippedWeapon);
        }

        [Fact]
        public void Inventory_EquippedArmorRemainsInInventory()
        {
            Player player = new Player("TestPlayer");

            Armor armor = new Armor(
                "Leather Armor",
                "Basic armor.",
                3,
                ItemRarity.Common,
                40);

            player.Inventory.AddItem(armor);

            player.Inventory.UseItem(armor, player);

            Assert.Contains(armor, player.Inventory.Items);
            Assert.Equal(armor, player.EquippedArmor);
        }

        [Fact]
        public void Inventory_CannotUseItemNotInInventory()
        {
            Player player = new Player("TestPlayer");

            Potion potion = new Potion(
                "Health Potion",
                "Restores 30 HP.",
                30,
                ItemRarity.Common,
                20);

            bool result =
                player.Inventory.UseItem(potion, player);

            Assert.False(result);
            Assert.Empty(player.Inventory.Items);
        }
    }
}