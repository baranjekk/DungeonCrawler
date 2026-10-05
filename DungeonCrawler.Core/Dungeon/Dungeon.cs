namespace DungeonCrawler.Core
{
    public class Dungeon
    {
        public List<Room> Rooms { get; }
        public int CurrentRoomIndex { get; private set; }
        public Room CurrentRoom => Rooms[CurrentRoomIndex];
        public bool IsLastRoom => CurrentRoomIndex == Rooms.Count - 1;
        public Dungeon()
        {
            Rooms = new List<Room>();
            CurrentRoomIndex = 0;
        }
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }
        public bool MoveToNextRoom()
        {
            if(CurrentRoomIndex >= Rooms.Count - 1) 
                return false;
            CurrentRoomIndex++;
            return true;
        }
    }
}
