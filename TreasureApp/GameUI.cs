using Core.Contracts;
using Core.Utils;
using System;
using System.Linq;
using TreasureApp.Core.Contracts;

namespace TreasureApp
{
    public class GameUI
    {
        private readonly IMazeIntegration _mazeIntegration;
        private readonly IHandleInput _handleInput;
        private readonly ILoadMaze _loadMaze;
        private readonly ILoadPlayer _loadPlayer;
        private readonly IRenderMaze _renderMaze;
        private readonly IExecuteUserAction _executeUserAction;

        private int _sizeOfMaze { get; set; }

        public GameUI(IMazeIntegration mazeIntegration, IHandleInput handleInput, ILoadMaze loadMaze,
            IRenderMaze renderMaze, ILoadPlayer loadPlayer, IExecuteUserAction executeUserAction)
        {
            _mazeIntegration = mazeIntegration;
            _handleInput = handleInput;
            _loadMaze = loadMaze;
            _renderMaze = renderMaze;
            _loadPlayer = loadPlayer;
            _executeUserAction = executeUserAction;

            InitializeSettings();
            PlayGame();

            Console.WriteLine(Constants.PlayerConstants.EOG);
            Console.ReadKey();
        }

        private void InitializeSettings()
        {
            // Get and set the player name
            var playerName = _handleInput.GetPlayerName();
            _loadPlayer.GetPlayerInstance().Name = playerName;

            // Get size of the maze matrix
            _sizeOfMaze = _handleInput.GetSizeOfMaze();
            _mazeIntegration.BuildMaze(_sizeOfMaze);

            // Set player on the entrance room
            _loadPlayer.GetPlayerInstance().CurrentRoom =
                _loadMaze.GetMazeMapInstance().mazeRooms.Where(r => r.IsEntrance).FirstOrDefault();
            _loadPlayer.GetPlayerInstance().HitPoints = _sizeOfMaze / 2;
        }

        private void PlayGame()
        {
            while (true)
            {               
                _renderMaze.DrawMazeGraphics(
                    _renderMaze.Generate2DMazeMatrixSymbols(_loadMaze.GetMazeMapInstance(), _loadPlayer.GetPlayerInstance()),
                    _loadMaze.GetMazeMapInstance().mazeSize);

                if (_loadPlayer.GetPlayerInstance().IsDead || _loadPlayer.GetPlayerInstance().FoundTreasure) return;
                ConsoleKey keyPressed = _handleInput.AskForKey();
                Console.WriteLine();

                switch (keyPressed)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.N:
                        Console.Clear();
                        _executeUserAction.Move('n');
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        _executeUserAction.Move('s');
                        break;
                    case ConsoleKey.E:
                        Console.Clear();
                        _executeUserAction.Move('e');
                        break;
                    case ConsoleKey.W:
                        Console.Clear();
                        _executeUserAction.Move('w');
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

    }
}
