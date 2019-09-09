using Core.Contracts;
using Core.Utils;
using System.Linq;
using TreasureApp.Core.Contracts;

namespace Core.Services
{
    public class MazeIntegrationService : IMazeIntegration
    {
        private readonly IBuildMaze _mazeBuilder;
        private readonly ILoadMaze _connectToMaze;

        public MazeIntegrationService(IBuildMaze mazeBuilder, ILoadMaze connectToMaze)
        {
            _mazeBuilder = mazeBuilder;
            _connectToMaze = connectToMaze;
        }

        public void BuildMaze(int size)
        {
            // We need to use the sqare number of size since we will have a 2D space.
            var matrixSize = size * size;

            _connectToMaze.GetMazeMapInstance().mazeRooms
                .AddRange(_mazeBuilder.CreateRooms(matrixSize, _mazeBuilder.ComputeNumberOfTraps(matrixSize)));
            _connectToMaze.GetMazeMapInstance().mazeSize = size;
        }

        public bool CausesInjury(int roomId)
        {
            var room = _connectToMaze.GetMazeMapInstance().mazeRooms.Where(r => r.Id == roomId).FirstOrDefault();

            if (room != null)
            {
                return room.HasTrap;
            }

            return false;
        }

        public string GetDescription(int roomId)
        {
            var room = _connectToMaze.GetMazeMapInstance().mazeRooms.Where(r => r.Id == roomId).FirstOrDefault();

            if (!room.Equals(null))
            {
                return room.Description;
            }

            return string.Empty;
        }

        public int GetEntranceRoom()
        {
            var room = _connectToMaze.GetMazeMapInstance().mazeRooms.Where(r => r.IsEntrance == true).FirstOrDefault();

            if (room != null)
            {
                return room.Id;
            }

            return -1;
        }

        public int? GetRoom(int roomId, char direction)
        {
            var searchedRoomId = RoomUtil.ComputeNextRoomId(roomId, direction, _connectToMaze.GetMazeMapInstance().mazeSize);

            var room = _connectToMaze.GetMazeMapInstance().mazeRooms.Where(r => r.Id == searchedRoomId).FirstOrDefault();
            if (room != null)
            {
                return room.Id;
            }

            return null;
        }

        public bool HasTreasure(int roomId)
        {
            var room = _connectToMaze.GetMazeMapInstance().mazeRooms.Where(r => r.Id == roomId).FirstOrDefault();

            if (room != null)
            {
                return room.HasTreasure;
            }

            return false;
        }

    }
}
