using DungeonCrawler.Core.Combat;

namespace DungeonCrawler.Core.Characters
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; private set; }
        public int BaseAttackPower { get; private set; }
        public int BaseDefense { get; private set; }
        public virtual int AttackPower => BaseAttackPower;
        public virtual int Defense => BaseDefense;
        public int Level { get; private set; }
        public Character(string name, int health, int maxHealth, int attackPower, int defense, int level)
        {
            Name = name;
            Health = health;
            MaxHealth = maxHealth;
            BaseAttackPower = attackPower;
            BaseDefense = defense;
            Level = level;
        }
        public virtual int TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - Defense);
            Health = Math.Max(0, Health - actualDamage);
            return actualDamage;
        }
        public void Heal(int healAmount)
        {
            Health = Math.Min(MaxHealth, Health + healAmount);
        }
        public bool IsAlive()
        { return Health > 0; }
        public virtual AttackResult Attack(Character target)
        {
            int damage = target.TakeDamage(AttackPower);
            return new AttackResult(damage, false, $"{Name} performs a normal attack.");
        }
        public void IncreaseBaseAttackPower(int amount)
        {
            BaseAttackPower += amount;
        }

        public void IncreaseBaseDefense(int amount)
        {
            BaseDefense += amount;
        }
        public void IncreaseMaxHealth(int amount)
        {
            MaxHealth += amount;
        }

        public void RestoreFullHealth()
        {
            Health = MaxHealth;
        }

        public void IncreaseLevel()
        {
            Level++;
        }
    }
}
