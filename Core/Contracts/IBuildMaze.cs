using Core.Models;
using System.Collections.Generic;

namespace Core.Contracts
{
    public interface IBuildMaze
    {
        /// <summary>Creates the rooms.</summary>
        /// <param name="roomsNumber">Number of the rooms in the maze</param>
        /// <param name="numberOfTraps">The number of traps.</param>
        /// <returns></returns>
        List<Room> CreateRooms(int roomsNumber, int numberOfTraps);

        /// <summary>Computes the treasure room identifier.</summary>
        /// <param name="roomsNumber">Number of the rooms in the maze</param>
        /// <param name="forbiddenIds">The forbidden ids.</param>
        /// <returns></returns>
        int ComputeTreasureRoomId(int roomsNumber, List<int> forbiddenIds);

        /// <summary>Computes the trap room identifier.</summary>
        /// <param name="roomsNumber">Number of the rooms in the maze</param>
        /// <param name="forbiddenIds">The forbidden ids.</param>
        /// <returns></returns>
        int ComputeTrapRoomId(int roomsNumber, List<int> forbiddenIds);

        /// <summary>Computes the entrance room identifier.</summary>
        /// <param name="roomsNumber">Number of the rooms in the maze</param>
        /// <returns></returns>
        int ComputeEntranceRoomId(int roomsNumber);

        /// <summary>Computes the number of traps.</summary>
        /// <param name="sizeOfMaze">The size of maze.</param>
        /// <returns></returns>
        int ComputeNumberOfTraps(int sizeOfMaze);

    }
}
