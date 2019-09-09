using Core.Models;

namespace Core.Contracts
{
    public interface ILoadPlayer
    {
        /// <summary>Gets the player instance.</summary>
        /// <returns></returns>
        Player GetPlayerInstance();
    }
}
