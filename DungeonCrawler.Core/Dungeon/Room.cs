using DungeonCrawler.Core.Characters;
using DungeonCrawler.Core.Combat;

namespace DungeonCrawler.Core
{
    public abstract class Room
    {
        public bool IsCleared { get; private set; }
        protected Room() 
        { 
            IsCleared = false;
        }
        public abstract void Enter(Player player, CombatSystem combatSystem);
        public void Clear()
        {
            IsCleared = true;
        }
    }
}
