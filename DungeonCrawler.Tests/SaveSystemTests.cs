using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Items;
using DungeonCrawler.Core.SaveLogic;

namespace DungeonCrawler.Tests
{
    public class SaveSystemTests
    {
        [Fact]
        public void SaveSystem_SaveAndLoadPreservesPlayerStats()
        {
            SaveSystem saveSystem = new SaveSystem();

            Player player = new Player("TestPlayer");

            player.TakeDamage(30);
            player.GainExperience(100);
            player.AddGold(50);

            try
            {
                saveSystem.SaveGame(player);

                Player? loadedPlayer =
                    saveSystem.LoadGame();

                Assert.NotNull(loadedPlayer);

                Assert.Equal("TestPlayer", loadedPlayer.Name);
                Assert.Equal(player.Health, loadedPlayer.Health);
                Assert.Equal(player.MaxHealth, loadedPlayer.MaxHealth);
                Assert.Equal(player.BaseAttackPower,
                    loadedPlayer.BaseAttackPower);
                Assert.Equal(player.BaseDefense,
                    loadedPlayer.BaseDefense);
                Assert.Equal(player.Level, loadedPlayer.Level);
                Assert.Equal(player.Experience,
                    loadedPlayer.Experience);
                Assert.Equal(player.Gold, loadedPlayer.Gold);
            }
            finally
            {
                if (File.Exists("savegame.json"))
                {
                    File.Delete("savegame.json");
                }
            }
        }

        [Fact]
        public void SaveSystem_SaveAndLoadPreservesInventory()
        {
            SaveSystem saveSystem = new SaveSystem();

            Player player = new Player("TestPlayer");

            Weapon weapon = new Weapon(
                "Test Sword",
                "Test weapon.",
                10,
                ItemRarity.Common,
                50);

            Armor armor = new Armor(
                "Test Armor",
                "Test armor.",
                5,
                ItemRarity.Common,
                40);

            Potion potion = new Potion(
                "Test Potion",
                "Restores HP.",
                30,
                ItemRarity.Common,
                20);

            player.Inventory.AddItem(weapon);
            player.Inventory.AddItem(armor);
            player.Inventory.AddItem(potion);

            try
            {
                saveSystem.SaveGame(player);

                Player? loadedPlayer =
                    saveSystem.LoadGame();

                Assert.NotNull(loadedPlayer);

                Assert.Equal(3,
                    loadedPlayer.Inventory.Items.Count);

                Assert.Contains(
                    loadedPlayer.Inventory.Items,
                    item => item.Name == "Test Sword");

                Assert.Contains(
                    loadedPlayer.Inventory.Items,
                    item => item.Name == "Test Armor");

                Assert.Contains(
                    loadedPlayer.Inventory.Items,
                    item => item.Name == "Test Potion");
            }
            finally
            {
                if (File.Exists("savegame.json"))
                {
                    File.Delete("savegame.json");
                }
            }
        }

        [Fact]
        public void SaveSystem_SaveAndLoadPreservesEquippedWeapon()
        {
            SaveSystem saveSystem = new SaveSystem();

            Player player = new Player("TestPlayer");

            Weapon weapon = new Weapon(
                "Test Sword",
                "Test weapon.",
                10,
                ItemRarity.Common,
                50);

            player.Inventory.AddItem(weapon);
            player.EquipWeapon(weapon);

            try
            {
                saveSystem.SaveGame(player);

                Player? loadedPlayer =
                    saveSystem.LoadGame();

                Assert.NotNull(loadedPlayer);
                Assert.NotNull(loadedPlayer.EquippedWeapon);
                Assert.Equal(
                    "Test Sword",
                    loadedPlayer.EquippedWeapon.Name);

                Assert.Equal(
                    35,
                    loadedPlayer.AttackPower);
            }
            finally
            {
                if (File.Exists("savegame.json"))
                {
                    File.Delete("savegame.json");
                }
            }
        }

        [Fact]
        public void SaveSystem_SaveAndLoadPreservesEquippedArmor()
        {
            SaveSystem saveSystem = new SaveSystem();

            Player player = new Player("TestPlayer");

            Armor armor = new Armor(
                "Test Armor",
                "Test armor.",
                5,
                ItemRarity.Common,
                40);

            player.Inventory.AddItem(armor);
            player.EquipArmor(armor);

            try
            {
                saveSystem.SaveGame(player);

                Player? loadedPlayer =
                    saveSystem.LoadGame();

                Assert.NotNull(loadedPlayer);
                Assert.NotNull(loadedPlayer.EquippedArmor);
                Assert.Equal(
                    "Test Armor",
                    loadedPlayer.EquippedArmor.Name);

                Assert.Equal(
                    15,
                    loadedPlayer.Defense);
            }
            finally
            {
                if (File.Exists("savegame.json"))
                {
                    File.Delete("savegame.json");
                }
            }
        }
    }
}