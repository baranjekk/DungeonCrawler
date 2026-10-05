using DungeonCrawler.Core.Items;

namespace DungeonCrawler.Core.Characters
{
    public class Player:Character
    {
        public Inventory Inventory { get; }
        public Weapon? EquippedWeapon { get; private set; }
        public Armor? EquippedArmor { get; private set; }
        public int Experience { get; private set; }
        public int ExperienceToNextLevel => Level * 100;
        public int Gold { get; private set; }
        public override int AttackPower => BaseAttackPower + (EquippedWeapon?.Damage ?? 0);
        public override int Defense => BaseDefense + (EquippedArmor?.Defense ?? 0);
        public Player(string name) : base(name, 100, 100, 25, 10, 1) 
        { 
            Inventory = new Inventory();
            Experience = 0;
            Gold = 100;
        }
        public void EquipWeapon(Weapon weapon)
        {
            if(!Inventory.Items.Contains(weapon))
            {
                return;
            }
            EquippedWeapon = weapon;
        }
        public void EquipArmor(Armor armor)
        {
            if (!Inventory.Items.Contains(armor))
            {
                return;
            }
            EquippedArmor = armor;
        }
        public void UnequipWeapon()
        {
            EquippedWeapon = null;
        }
        public void UnequipArmor()
        {
            EquippedArmor = null;
        }
        public void GainExperience(int amount)
        {
            Experience += amount;
            while(Experience >= ExperienceToNextLevel)
            {
                Experience -= ExperienceToNextLevel;
                LevelUp();
            }
        }
        private void LevelUp()
        {
            IncreaseLevel();
            IncreaseMaxHealth(10);
            RestoreFullHealth();
            IncreaseBaseAttackPower(2);
            IncreaseBaseDefense(1);
        }
        public void AddGold(int amount)
        {
            if (amount < 0)
                return;

            Gold += amount;
        }
        public bool SpendGold(int amount)
        {
            if (amount < 0 || amount > Gold)
                return false;

            Gold -= amount;
            return true;
        }
        public void IncreaseLevelTo(int targetLevel)
        {
            while (Level < targetLevel)
            {
                IncreaseLevel();
            }
        }
        public void SetHealth(int health)
        {
            Health = Math.Min(health, MaxHealth);
        }
        public void SetExperience(int experience)
        {
            Experience = experience;
        }
        public void SetGold(int gold)
        {
            Gold = gold;
        }
    }
}
