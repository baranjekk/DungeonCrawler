using System.Text.Json;
using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Items;

namespace DungeonCrawler.Core.SaveLogic
{
    public class SaveSystem
    {
        private const string SaveFile = "savegame.json";
        public void SaveGame(Player player)
        {
            SaveData saveData = new SaveData
            {
                Name = player.Name,
                Health = player.Health,
                MaxHealth = player.MaxHealth,
                BaseAttackPower = player.BaseAttackPower,
                BaseDefense = player.BaseDefense,
                Level = player.Level,
                Experience = player.Experience,
                Gold = player.Gold,
                EquippedWeaponName = player.EquippedWeapon?.Name,
                EquippedArmorName = player.EquippedArmor?.Name,
                Items = new List<ItemSaveData>()
            };
            foreach (Item item in player.Inventory.Items)
            {
                if (item is Weapon weapon)
                {
                    saveData.Items.Add(new ItemSaveData
                    {
                        Type = "Weapon",
                        Name = weapon.Name,
                        Description = weapon.Description,
                        Rarity = weapon.Rarity,
                        Price = weapon.Price,
                        Damage = weapon.Damage
                    });
                }
                else if (item is Armor armor)
                {
                    saveData.Items.Add(new ItemSaveData
                    {
                        Type = "Armor",
                        Name = armor.Name,
                        Description = armor.Description,
                        Rarity = armor.Rarity,
                        Price = armor.Price,
                        Defense = armor.Defense
                    });
                }
                else if (item is Potion potion)
                {
                    saveData.Items.Add(new ItemSaveData
                    {
                        Type = "Potion",
                        Name = potion.Name,
                        Description = potion.Description,
                        Rarity = potion.Rarity,
                        Price = potion.Price,
                        HealAmount = potion.HealAmount
                    });
                }
            }
            string json = JsonSerializer.Serialize(
                saveData,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            File.WriteAllText(SaveFile, json);
        }

        public Player? LoadGame()
        {
            if (!File.Exists(SaveFile))
                return null;
            string json = File.ReadAllText(SaveFile);
            SaveData? saveData = JsonSerializer.Deserialize<SaveData>(json);
            if (saveData == null)
                return null;
            Player player = new Player(saveData.Name);
            player.IncreaseBaseAttackPower(saveData.BaseAttackPower - player.BaseAttackPower);
            player.IncreaseBaseDefense(saveData.BaseDefense - player.BaseDefense);
            player.IncreaseMaxHealth(saveData.MaxHealth - player.MaxHealth);
            player.IncreaseLevelTo(saveData.Level);
            player.SetHealth(saveData.Health);
            player.SetExperience(saveData.Experience);
            player.SetGold(saveData.Gold);
            foreach (ItemSaveData itemData in saveData.Items)
            {
                Item? item = CreateItem(itemData);

                if (item != null)
                {
                    player.Inventory.AddItem(item);
                }
            }
            foreach (Item item in player.Inventory.Items)
            {
                if (item.Name == saveData.EquippedWeaponName &&
                    item is Weapon weapon)
                {
                    player.EquipWeapon(weapon);
                }
                if (item.Name == saveData.EquippedArmorName &&
                    item is Armor armor)
                {
                    player.EquipArmor(armor);
                }
            }
            return player;
        }
        private Item? CreateItem(ItemSaveData data)
        {
            return data.Type switch
            {
                "Weapon" => new Weapon(
                    data.Name,
                    data.Description,
                    data.Damage,
                    data.Rarity,
                    data.Price),

                "Armor" => new Armor(
                    data.Name,
                    data.Description,
                    data.Defense,
                    data.Rarity,
                    data.Price),

                "Potion" => new Potion(
                    data.Name,
                    data.Description,
                    data.HealAmount,
                    data.Rarity,
                    data.Price),

                _ => null
            };
        }
    }
    public class SaveData
    {
        public string Name { get; set; } = "";
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int BaseAttackPower { get; set; }
        public int BaseDefense { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public string? EquippedWeaponName { get; set; }
        public string? EquippedArmorName { get; set; }
        public List<ItemSaveData> Items { get; set; } = new();
    }
    public class ItemSaveData
    {
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public ItemRarity Rarity { get; set; }
        public int Price { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int HealAmount { get; set; }
    }
}