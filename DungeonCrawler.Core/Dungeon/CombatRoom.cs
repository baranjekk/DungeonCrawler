using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Combat;

namespace DungeonCrawler.Core
{
    public class CombatRoom : Room
    {
        public Enemy Enemy { get; }
        public CombatRoom(Enemy enemy)
        {
            Enemy = enemy;
        }
        public override void Enter(Player player, CombatSystem combatSystem)
        {
            Console.Clear();
            Console.WriteLine($"You encountered a {Enemy.Name}!");
            Console.WriteLine("\nPress any key to fight...");
            Console.ReadKey();
            CombatResult result = combatSystem.Fight(player, Enemy);
            if (result == CombatResult.PlayerWon)
                Clear();
        }
    }
}
