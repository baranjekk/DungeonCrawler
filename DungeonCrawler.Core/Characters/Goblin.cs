using DungeonCrawler.Core.Combat;

namespace DungeonCrawler.Core.Characters
{
    public class Goblin : Enemy
    {
        private Random random = new Random();
        public Goblin() : base("Goblin", 50, 50, 15, 5, 1, 25, 15) { }

        public override AttackResult Attack(Character target)
        {
            if (random.Next(100) < 20)
            {
                int damage = target.TakeDamage(AttackPower * 2);
                return new AttackResult(damage, true, "Goblin performs a sneaky attack!");
            }

            return base.Attack(target);
        }
    }
}
