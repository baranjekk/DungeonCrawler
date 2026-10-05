namespace DungeonCrawler.Core.Characters
{
    public class Orc : Enemy
    {
        private readonly Random random = new Random();
        public Orc()
            : base("Orc", 100, 100, 25, 10, 3, 75, 40)
        {
        }
        public override int TakeDamage(int damage)
        {
            if (random.Next(100) < 20)
            {
                int reducedDamage = (int)Math.Ceiling(damage * 0.5);

                int actualDamage = base.TakeDamage(reducedDamage);

                Console.WriteLine(
                    $"The Orc raises its guard! Damage reduced from {damage} to {reducedDamage}.");

                return actualDamage;
            }

            return base.TakeDamage(damage);
        }
    }
}
