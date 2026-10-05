namespace DungeonCrawler.Core.Characters
{
    public class Enemy : Character
    {
        public int ExperienceReward { get; }
        public int GoldReward { get; protected set; }
        public Enemy(string name, int health, int maxHealth, int attackPower, int defense, int level, int experienceReward, int goldReward) : base(name, health, maxHealth, attackPower, defense, level) 
        {
            ExperienceReward = experienceReward;
            GoldReward = goldReward;
        }
    }
}
