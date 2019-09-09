namespace Core.Utils
{
    public static class Constants
    {
        public static class RoomConstants
        {
            public const string EntranceRoomDescription = "You have found the entrance to the treasure maze.";
            public const string TrapRoomDescription = "You have encountered a trapped room.";
            public const string TreasureRoomDescription = "You have found the ancient treasure. Congratulations!";
            public const string TrapRoomEvent = "You have a disease and you bleed!";
            public const string TreasureRoomEvent = "Your efforts has been rewarded!";
            public const string CheckForTreasure = "You are searching carefully the surroundings for a treasure.";
            public const string NormalRoomDescription = "The room that you entered looks similar to all other rooms.";
        }

        public static class PlayerConstants
        {
            public const string HPDrainDescription = "Since you bleed your HP are decreased by 1 point.";
            public const string PlayerDead = "You died!";
            public const string InvalidDirection = "You cannot go in that direction. Maze is ending.";
            public const string EOG = "End of Game!";
        }

        public static class RenderSymbolConstants
        {
            public const string TreasureSymbol = "$";
            public const string FloorTileSymbol = ".";
            public const string TrapSymbol = "!";
            public const string WallSymbol = "#";
            public const string GateSymbol = "+";
            public const string EntranceSymbol = "@";
            public const string PlayerSymbol = "X";
            public const string UnExploredSymbol = "?";
        }
    }
}
