using Core.Models;

namespace Core.Contracts
{
    public interface IRenderMaze
    {
        /// <summary>Draws the maze graphics.</summary>
        /// <param name="mazeSymbols">The maze symbols.</param>
        /// <param name="mazeSize"></param>
        void DrawMazeGraphics(string[,] mazeSymbols, int mazeSize);

        /// <summary>Generates the maze matrix symbols.</summary>
        /// <param name="mazeMap">The maze map.</param>
        /// <param name="player">The player.</param>
        /// <returns></returns>
        string[,] Generate2DMazeMatrixSymbols(MazeMap mazeMap, Player player);
    }
}
