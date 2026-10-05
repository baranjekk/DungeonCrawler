using DungeonCrawler.Core.Combat;

namespace DungeonCrawler.Core.Characters
{
    public class Boss : Enemy
    {
        private readonly Random random = new Random();
        public Boss()
            : base("Dungeon Boss", 150, 150, 30, 15, 5, 150, 80)
        {
        }
        public override AttackResult Attack(Character target)
        {
            if (random.Next(100) < 25)
            {
                int damage = target.TakeDamage(40);
                return new AttackResult(damage, true, $"The Dungeon Boss used DEVASTATING STRIKE and dealt {damage} damage!");
            }
            return base.Attack(target);
        }

    }
}
