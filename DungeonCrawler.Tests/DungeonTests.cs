using DungeonCrawler.Core;
using DungeonCrawler.Core.Characters;

namespace DungeonCrawler.Tests
{
    public class DungeonTests
    {
        [Fact]
        public void Dungeon_StartsAtFirstRoom()
        {
            Dungeon dungeon = new Dungeon();

            dungeon.AddRoom(new TestRoom());
            dungeon.AddRoom(new TestRoom());

            Assert.Equal(0, dungeon.CurrentRoomIndex);
            Assert.False(dungeon.IsLastRoom);
        }

        [Fact]
        public void Dungeon_MoveToNextRoomWorks()
        {
            Dungeon dungeon = new Dungeon();

            dungeon.AddRoom(new TestRoom());
            dungeon.AddRoom(new TestRoom());
            dungeon.AddRoom(new TestRoom());

            bool result = dungeon.MoveToNextRoom();

            Assert.True(result);
            Assert.Equal(1, dungeon.CurrentRoomIndex);
        }

        [Fact]
        public void Dungeon_CannotMovePastLastRoom()
        {
            Dungeon dungeon = new Dungeon();

            dungeon.AddRoom(new TestRoom());
            dungeon.AddRoom(new TestRoom());

            dungeon.MoveToNextRoom();

            bool result = dungeon.MoveToNextRoom();

            Assert.False(result);
            Assert.Equal(1, dungeon.CurrentRoomIndex);
            Assert.True(dungeon.IsLastRoom);
        }

        [Fact]
        public void Dungeon_GeneratorCreatesCorrectNumberOfRooms()
        {
            DungeonGenerator generator = new DungeonGenerator();

            Dungeon dungeon = generator.Generate(5);

            Assert.Equal(5, dungeon.Rooms.Count);
        }

        [Fact]
        public void Dungeon_GeneratorAlwaysPlacesBossRoomLast()
        {
            DungeonGenerator generator = new DungeonGenerator();

            Dungeon dungeon = generator.Generate(5);

            Assert.IsType<BossRoom>(
                dungeon.Rooms[dungeon.Rooms.Count - 1]);
        }

        [Fact]
        public void Dungeon_GeneratorStartsAtFirstRoom()
        {
            DungeonGenerator generator = new DungeonGenerator();

            Dungeon dungeon = generator.Generate(5);

            Assert.Equal(0, dungeon.CurrentRoomIndex);
            Assert.False(dungeon.IsLastRoom);
        }

        private class TestRoom : Room
        {
            public override void Enter(
                Player player,
                DungeonCrawler.Core.Combat.CombatSystem combatSystem)
            {
            }
        }
    }
}