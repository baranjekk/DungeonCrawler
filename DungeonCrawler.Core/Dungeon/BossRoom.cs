using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Combat;

namespace DungeonCrawler.Core
{
    public class BossRoom : Room
    {
        public Boss Boss { get;}
        public BossRoom(Boss boss)
        {
            Boss = boss;
        }
        public override void Enter(Player player, CombatSystem combatSystem)
        {
            Console.Clear();
            Console.WriteLine("=== BOSS ROOM ===");
            Console.WriteLine($"\nYou have encountered {Boss.Name}!");
            Console.WriteLine("\nPress any key to begin the final battle...");
            Console.ReadKey();
            CombatResult result = combatSystem.Fight(player, Boss);
            if (result == CombatResult.PlayerWon)
            {
                Clear();
                Console.Clear();
                Console.WriteLine("=== BOSS DEFEATED ===");
                Console.WriteLine("\nYou have defeated the dungeon boss!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
