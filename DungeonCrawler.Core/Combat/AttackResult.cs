namespace DungeonCrawler.Core.Combat
{
    public class AttackResult
    {
        public int Damage { get; }
        public bool IsSpecialAttack { get; }
        public string Description { get; }
        public AttackResult(int damage, bool isSpecialAttack, string description)
        {
            Damage = damage;
            IsSpecialAttack = isSpecialAttack;
            Description = description;
        }
    }
}
