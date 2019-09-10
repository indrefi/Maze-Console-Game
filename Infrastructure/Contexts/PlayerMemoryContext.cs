using Core.Contracts;
using Core.Models;

namespace Infrastructure.Contexts
{
    public class PlayerMemoryContext: ILoadPlayer
    {
        private static Player _playerInstance { get; set; }
        private readonly object _Lock = new object();

        public Player GetPlayerInstance()
        {
            if (_playerInstance == null)
            {
                lock (_Lock)
                {
                    if (_playerInstance == null)
                    {
                        _playerInstance = new Player { CurrentRoom = new Room()};
                    }
                }
            }

            return _playerInstance;
        }
    }
}
