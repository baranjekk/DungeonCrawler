using DungeonCrawler.Core.Characters;

namespace DungeonCrawler.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void Character_StartsWithCorrectStats()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                5,
                1);

            Assert.Equal("TestCharacter", character.Name);
            Assert.Equal(100, character.Health);
            Assert.Equal(100, character.MaxHealth);
            Assert.Equal(20, character.AttackPower);
            Assert.Equal(5, character.Defense);
            Assert.Equal(1, character.Level);
        }

        [Fact]
        public void Character_TakeDamageAccountsForDefense()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                5,
                1);

            int damage = character.TakeDamage(20);

            Assert.Equal(15, damage);
            Assert.Equal(85, character.Health);
        }

        [Fact]
        public void Character_TakeDamageAlwaysDealsAtLeastOneDamage()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                100,
                1);

            int damage = character.TakeDamage(20);

            Assert.Equal(1, damage);
            Assert.Equal(99, character.Health);
        }

        [Fact]
        public void Character_HealthCannotGoBelowZero()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                5,
                1);

            character.TakeDamage(1000);

            Assert.Equal(0, character.Health);
            Assert.False(character.IsAlive());
        }

        [Fact]
        public void Character_HealRestoresHealth()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                5,
                1);

            character.TakeDamage(30);
            character.Heal(20);

            Assert.Equal(95, character.Health);
        }

        [Fact]
        public void Character_HealCannotExceedMaxHealth()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                5,
                1);

            character.TakeDamage(10);
            character.Heal(100);

            Assert.Equal(100, character.Health);
        }

        [Fact]
        public void Character_IncreaseAttackPowerWorks()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                5,
                1);

            character.IncreaseBaseAttackPower(10);

            Assert.Equal(30, character.BaseAttackPower);
            Assert.Equal(30, character.AttackPower);
        }

        [Fact]
        public void Character_IncreaseDefenseWorks()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                5,
                1);

            character.IncreaseBaseDefense(10);

            Assert.Equal(15, character.BaseDefense);
            Assert.Equal(15, character.Defense);
        }

        [Fact]
        public void Character_IncreaseMaxHealthWorks()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                5,
                1);

            character.IncreaseMaxHealth(25);

            Assert.Equal(125, character.MaxHealth);
        }

        [Fact]
        public void Character_RestoreFullHealthWorks()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                5,
                1);

            character.TakeDamage(40);
            character.RestoreFullHealth();

            Assert.Equal(100, character.Health);
        }

        [Fact]
        public void Character_IncreaseLevelWorks()
        {
            Character character = new Character(
                "TestCharacter",
                100,
                100,
                20,
                5,
                1);

            character.IncreaseLevel();

            Assert.Equal(2, character.Level);
        }
    }
}