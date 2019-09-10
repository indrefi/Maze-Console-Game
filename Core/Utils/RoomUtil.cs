using Core.Models;
using System;

namespace Core.Utils
{
    public class RoomUtil
    {
        /// <summary>Computes the next room identifier.</summary>
        /// <param name="roomId">The room identifier.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="mazeSize"></param>
        /// <returns></returns>
        public static int ComputeNextRoomId(int roomId, char direction, int mazeSize)
        {            
            var chosenDirection = direction.ToString().ToLower();
            var searchedRoomId = roomId;

            switch (chosenDirection)
            {
                case "s":
                    searchedRoomId = searchedRoomId + mazeSize;
                    break;
                case "n":
                    searchedRoomId = searchedRoomId - mazeSize;
                    break;
                case "w":
                    searchedRoomId = searchedRoomId - 1;
                    // Check if move is allowed not to cross walls
                    if (!IsAllowedMove(roomId, searchedRoomId, mazeSize * mazeSize))
                        searchedRoomId = -1;
                    break;
                case "e":
                    searchedRoomId = searchedRoomId + 1;
                    // Check if move is allowed not to cross walls
                    if (!IsAllowedMove(roomId, searchedRoomId, mazeSize * mazeSize))
                        searchedRoomId = -1;
                    break;
                default:
                    break;
            }

            return searchedRoomId;
        }

        /// <summary>Generates the pseudo random number.</summary>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        public static int GeneratePseudoRandomNumber(int maxValue)
        {
            int seed = (int)DateTime.UtcNow.Ticks;
            Random random = new Random(seed);
            return random.Next(0, maxValue);
        }

        /// <summary>Generates the room description.</summary>
        /// <param name="room">The room.</param>
        /// <returns></returns>
        public static string GenerateRoomDescription(Room room)
        {
            if (room.IsEntrance) return Constants.RoomConstants.EntranceRoomDescription;
            if (room.HasTrap) return Constants.RoomConstants.TrapRoomDescription;
            if (room.HasTreasure) return Constants.RoomConstants.TreasureRoomDescription;
            if (!room.HasTreasure && !room.HasTrap && !room.IsEntrance) return Constants.RoomConstants.NormalRoomDescription;

            return string.Empty;
        }

        /// <summary>Determines if the move is allowed not to cross walls.</summary>
        /// <param name="room">The room.</param>
        /// <param name="secondRoom">The second room.</param>
        /// <param name="numberOfRooms">The number of rooms.</param>
        /// <returns>If move is possible or not even the rooms exists</returns>
        public static bool IsAllowedMove(int room, int secondRoom, int numberOfRooms)
        {
            var size = (int)Math.Sqrt(numberOfRooms);
            var xRoom = room / size;
            var xSecondRoom = secondRoom / size;

            if (xRoom == xSecondRoom) return true;

            return false;
        }
    }
}
