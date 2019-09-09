using Core.Contracts;
using Core.Utils;
using System;
using System.Linq;
using TreasureApp.Core.Contracts;

namespace Core.Services
{
    public class ExecuteUserActionService : IExecuteUserAction
    {
        private readonly ILoadPlayer _loadPlayer;
        private readonly IMazeIntegration _mazeIntegration;
        private readonly ILoadMaze _loadMaze;

        public ExecuteUserActionService(ILoadPlayer loadPlayer, IMazeIntegration mazeIntegration, ILoadMaze loadMaze )
        {
            _loadPlayer = loadPlayer;
            _mazeIntegration = mazeIntegration;
            _loadMaze = loadMaze;
        }

        public void CheckCurrentRoom()
        {
            Console.WriteLine(Constants.RoomConstants.CheckForTreasure);
            Console.WriteLine(_mazeIntegration.GetDescription(_loadPlayer.GetPlayerInstance().CurrentRoom.Id));

            if (_mazeIntegration.CausesInjury(_loadPlayer.GetPlayerInstance().CurrentRoom.Id))
            {
                Console.WriteLine(Constants.RoomConstants.TrapRoomEvent);
            }
            if (_mazeIntegration.HasTreasure(_loadPlayer.GetPlayerInstance().CurrentRoom.Id))
            {
                Console.WriteLine(Constants.RoomConstants.TreasureRoomEvent);
                _loadPlayer.GetPlayerInstance().FoundTreasure = true;
            }
        }

        public void CheckSelf()
        {
            if (_loadPlayer.GetPlayerInstance().CurrentRoom.HasTrap)
            {
                Console.WriteLine(Constants.PlayerConstants.HPDrainDescription);
                _loadPlayer.GetPlayerInstance().HitPoints--;
            }

            if(_loadPlayer.GetPlayerInstance().HitPoints <= 0)
            {
                Console.WriteLine(Constants.PlayerConstants.PlayerDead);
                _loadPlayer.GetPlayerInstance().IsDead = true;
            }
        }

        public void Move(char direction)
        {
            var newRoomId = _mazeIntegration.GetRoom(_loadPlayer.GetPlayerInstance().CurrentRoom.Id, direction);
            if(newRoomId.HasValue)
            {
                _loadMaze.GetMazeMapInstance().mazeRooms.Where(r => r.Id == newRoomId).FirstOrDefault().IsVisited = true;
                _loadPlayer.GetPlayerInstance().CurrentRoom = 
                    _loadMaze.GetMazeMapInstance().mazeRooms.Where(r => r.Id == newRoomId).FirstOrDefault();
                _loadPlayer.GetPlayerInstance().StepsMade++;
                CheckCurrentRoom();
                CheckSelf();
            }
            else
            {
                Console.WriteLine(Constants.PlayerConstants.InvalidDirection);
            }
        }
    }
}
