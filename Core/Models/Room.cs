namespace Core.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasTrap { get; set; }
        public bool HasTreasure { get; set; }
        public bool IsEntrance { get; set; }
        public bool IsVisited { get; set; }
        public string Description { get; set; }
    }
}
