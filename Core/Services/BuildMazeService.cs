using Core.Contracts;
using Core.Models;
using Core.Utils;
using System;
using System.Collections.Generic;

namespace Core.Services
{
    public class BuildMazeService : IBuildMaze
    {
        public List<Room> CreateRooms(int roomsNumber, int numberOfTraps)
        {
            var rooms = new List<Room>();
            List<int> forbiddenIds = new List<int>(); // Not allow to add treasure or trap room id list
            List<int> trapIds = new List<int>();
            
            // Compute entrance room Id
            var entranceId = ComputeEntranceRoomId(roomsNumber);
            forbiddenIds.Add(entranceId);

            // Compute the list of trap room Ids
            for(int trap = 0; trap < numberOfTraps; trap++)
            {
                var trapIdd = ComputeTrapRoomId(roomsNumber, forbiddenIds);
                forbiddenIds.Add(trapIdd); // Not to overlapp with another trap
                trapIds.Add(trapIdd);
            }

            // Compute treasure room Id
            var treasureId = ComputeTreasureRoomId(roomsNumber, forbiddenIds);
            
            // Create rooms
            for (int x = 0; x < Math.Sqrt(roomsNumber); x++)
            {
                for (int y = 0; y < Math.Sqrt(roomsNumber); y++)
                {
                    var roomId = x * (int)Math.Sqrt(roomsNumber) + y; // Create a number based on the tile position in the matrix
                    //  TODO add descriptions for room 
                    var room = new Room
                    {
                        X = x, // Save tile position
                        Y = y, // Save tile position
                        Id = roomId,
                        HasTrap = trapIds.Contains(roomId),
                        HasTreasure = treasureId == roomId ? true : false,
                        IsEntrance = entranceId == roomId ? true : false,
                        IsVisited = entranceId == roomId ? true : false,
                    };
                    room.Description = RoomUtil.GenerateRoomDescription(room);
                    rooms.Add(room);
                }
            }

            return rooms;
        }

        public int ComputeEntranceRoomId(int roomsNumber)
        {
            // Random selection of entrance
            // The only rule is to be on the edges which means that one of axis(x or y) 
            // has to be 0 or maxValue-1 since we are counting from 0.
            int possibleRoomId = 0;

            while (true)
            {
                possibleRoomId = RoomUtil.GeneratePseudoRandomNumber(roomsNumber - 1);

                // Get room position on axys -- reverse process of constructing id
                var size = (int)Math.Sqrt(roomsNumber);
                var y = possibleRoomId % 10;
                var x = possibleRoomId / size;

                // Check that room has external walls on the edge.
                if (y == 0 || y == size - 1 || x == 0 || x == size - 1) return possibleRoomId;
            }
        }

        public int ComputeTrapRoomId(int roomsNumber, List<int> forbiddenIds)
        {
            // Set random, only rule not to be in the same room as entrance
            // Additional business rules could be added.
            int possibleRoomId = 0;

            while (true)
            {
                possibleRoomId = RoomUtil.GeneratePseudoRandomNumber(roomsNumber);
                if (!forbiddenIds.Contains(possibleRoomId)) return possibleRoomId;
            }
        }

        public int ComputeTreasureRoomId(int roomsNumber, List<int> forbiddenIds)
        {
            // Set random, only rule not the be in the same room as entrace or trap
            // Additional business rules could be added.
            int possibleRoomId = 0;

            while (true)
            {
                possibleRoomId = RoomUtil.GeneratePseudoRandomNumber(roomsNumber);
                if (!forbiddenIds.Contains(possibleRoomId)) return possibleRoomId;
            }
        }

        public int ComputeNumberOfTraps(int sizeOfMaze)
        {
            var maxNumber = (sizeOfMaze / 3) + 1;
            return RoomUtil.GeneratePseudoRandomNumber(maxNumber); // Total number of traps
        }

    }
}
