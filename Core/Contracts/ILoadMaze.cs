using Core.Models;

namespace Core.Contracts
{
    public interface ILoadMaze
    {
        /// <summary>Gets the maze map instance.</summary>
        /// <returns></returns>
        MazeMap GetMazeMapInstance(); 
    }
}
