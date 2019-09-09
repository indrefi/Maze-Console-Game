using Core.Contracts;
using Core.Models;
using System.Collections.Generic;

namespace Infrastructure.Contexts
{
    public class MazeMemoryContext: ILoadMaze
    {
        private static MazeMap _mazeMapInstance { get; set; }
        private readonly object _Lock = new object();

        public MazeMap GetMazeMapInstance()
        {
            if (_mazeMapInstance == null)
            {
                lock (_Lock)
                {
                    if (_mazeMapInstance == null)
                    {
                        _mazeMapInstance = new MazeMap { mazeRooms = new List<Room>()};
                    }
                }
            }

            return _mazeMapInstance;
        }
    }
}
