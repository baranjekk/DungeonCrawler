using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Combat;

namespace DungeonCrawler.Core
{
    public class HealingRoom : Room
    {
        private readonly int healAmount;
        public HealingRoom(int healAmount)
        {
            this.healAmount = healAmount;
        }
        public override void Enter(Player player, CombatSystem combatSystem)
        {
            Console.Clear();
            Console.WriteLine("You found a healing room!");
            int oldHealth = player.Health;
            player.Heal(healAmount);
            int healedAmount = player.Health - oldHealth;
            Console.WriteLine($"\nYou recovered {healedAmount} HP." +
                $"\nHP: {player.Health}/{player.MaxHealth}");
            Clear();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
