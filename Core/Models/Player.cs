namespace Core.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int StepsMade { get; set; }
        public Room CurrentRoom { get; set; }
        public bool IsDead { get; set; }
        public bool FoundTreasure { get; set; }
    }
}
