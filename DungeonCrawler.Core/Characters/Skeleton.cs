using DungeonCrawler.Core.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Core.Characters
{
    public class Skeleton : Enemy
    {
        private readonly Random random = new Random();
        public Skeleton()
            : base("Skeleton", 60, 60, 18, 7, 2, 40, 25)
        {
        }
        public override AttackResult Attack(Character target)
        {
            if (random.Next(100) < 25)
            {
                int damage = target.TakeDamage(AttackPower + 8);
                return new AttackResult(
                    damage,
                    true,
                    "Skeleton performs a Bone Strike!");
            }
            return base.Attack(target);
        }
    }
}
