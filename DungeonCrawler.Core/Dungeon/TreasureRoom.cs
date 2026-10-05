using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Combat;
using DungeonCrawler.Core.Items;

namespace DungeonCrawler.Core
{
    public class TreasureRoom : Room
    {
        private readonly Item item;
        public TreasureRoom(Item item)
        {
            this.item = item;
        }
        public override void Enter(Player player, CombatSystem combatSystem)
        {
            Console.Clear();
            Console.WriteLine("You found a treasure room!");
            Console.WriteLine($"\nYou found: {item.Name}");
            Console.WriteLine(item.Description);
            player.Inventory.AddItem(item);
            Console.WriteLine("\nThe item has been added to your inventory.");
            Clear();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
