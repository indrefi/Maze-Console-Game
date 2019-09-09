using Core.Contracts;
using Core.Models;
using Core.Utils;
using System;
using System.Text;

namespace Core.Services
{
    public class RenderMazeService: IRenderMaze
    {
        private int _sizeOfATile { get; set; } = 5; // Number of points associated for each room (take into consideration walls also)

        public void DrawMazeGraphics(string[,] mazeSymbols, int mazeSize)
        {
            var sizeOfARow = mazeSize * _sizeOfATile; // Each Room is 5 points in the maze map

            // Print the legent of the maze
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n Symbol legend: \n");
            stringBuilder.Append($"Treasure = {Constants.RenderSymbolConstants.TreasureSymbol} \n");
            stringBuilder.Append($"Trap = {Constants.RenderSymbolConstants.TrapSymbol} \n");
            stringBuilder.Append($"Wall = {Constants.RenderSymbolConstants.WallSymbol} \n");
            stringBuilder.Append($"Gate = {Constants.RenderSymbolConstants.GateSymbol} \n");
            stringBuilder.Append($"Entrance = {Constants.RenderSymbolConstants.EntranceSymbol} \n");
            stringBuilder.Append($"Player = {Constants.RenderSymbolConstants.PlayerSymbol} \n");
            stringBuilder.Append($"UnExplored = {Constants.RenderSymbolConstants.UnExploredSymbol} \n");

            Console.WriteLine(stringBuilder.ToString());

            // Print maze structure
            for (var x = 0; x < (sizeOfARow); x++)
            {
                for (var y = 0; y < (sizeOfARow); y++)
                {
                    Console.Write(mazeSymbols[x, y]);
                }
                Console.WriteLine();
            }
        }

        public string[,] Generate2DMazeMatrixSymbols(MazeMap mazeMap, Player player)
        {
            var sizeOfARow = mazeMap.mazeSize * _sizeOfATile; // Each Room is 5 points in the maze map
            string[,] mazeMapSymbols = new string[sizeOfARow, sizeOfARow];

            // Generate symbols for each room
            foreach (var room in mazeMap.mazeRooms)
            {
                // Each room has it's own 2D axys
                for (var x = 0; x < _sizeOfATile; x++)
                {
                    for (var y = 0; y < _sizeOfATile; y++)
                    {
                        // If room was not visited we do not show any information about it
                        if (!room.IsVisited)
                        {
                            mazeMapSymbols[room.X * _sizeOfATile + x, room.Y * _sizeOfATile + y] = 
                                Constants.RenderSymbolConstants.UnExploredSymbol;
                        }
                        else
                        {
                            // Mark floor of tiles
                            mazeMapSymbols[room.X * _sizeOfATile + x, room.Y * _sizeOfATile + y] =
                                Constants.RenderSymbolConstants.FloorTileSymbol;

                            // Mark walls
                            if (x == 0 || y == 0 || x == _sizeOfATile - 1 || y == _sizeOfATile - 1)
                            {
                                // If x or y are on the edges of tiles mark all of them as walls.
                                mazeMapSymbols[room.X * _sizeOfATile + x, room.Y * _sizeOfATile + y] = 
                                    Constants.RenderSymbolConstants.WallSymbol;
                            }
                            // Mark gates
                            if ((x == 2 && (y == _sizeOfATile - 1 || y == 0)) || (y == 2 && (x == _sizeOfATile - 1 || x == 0)))
                            {
                                mazeMapSymbols[(room.X * _sizeOfATile) + x, (room.Y * _sizeOfATile) + y] = Constants.RenderSymbolConstants.GateSymbol;
                            }
                            // Mark entrance
                            if (room.IsEntrance)
                            {
                                // Mark the conrner of the tile as entrance
                                if(x == 0)
                                {
                                    mazeMapSymbols[room.X * _sizeOfATile + x, (room.Y * _sizeOfATile)] =
                                    Constants.RenderSymbolConstants.EntranceSymbol;
                                }                                
                            }
                            // Mark traps
                            if (room.HasTrap)
                            {
                                // Find tile position (room.X * _sizeOfATile). Find center of room  (_sizeOfATile / 2)
                                mazeMapSymbols[(room.X * _sizeOfATile) + (_sizeOfATile / 2), (room.Y * _sizeOfATile) + (_sizeOfATile / 2)] = 
                                    Constants.RenderSymbolConstants.TrapSymbol;
                            }
                            // Mark treasure
                            if (room.HasTreasure)
                            {
                                // Find tile position (room.X * _sizeOfATile). Find center of room  (_sizeOfATile / 2)
                                mazeMapSymbols[(room.X * _sizeOfATile) + (_sizeOfATile / 2), (room.Y * _sizeOfATile) + (_sizeOfATile / 2)] = 
                                    Constants.RenderSymbolConstants.TreasureSymbol;
                            }
                            //Draw player on the map
                            if (player.CurrentRoom.Id.Equals(room.Id))
                            {
                                // Find tile position (room.X * _sizeOfATile). Find center of room  (_sizeOfATile / 2)
                                mazeMapSymbols[(room.X * _sizeOfATile) + (_sizeOfATile / 2), (room.Y * _sizeOfATile) + (_sizeOfATile / 2)] = 
                                    Constants.RenderSymbolConstants.PlayerSymbol;
                            }
                        }                       
                    }
                }
            }

            return mazeMapSymbols;
        }

    }
}
