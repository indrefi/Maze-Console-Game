using System;

namespace Core.Contracts
{
    public interface IHandleInput
    {
        /// <summary>Gets the size of the maze.</summary>
        /// <returns></returns>
        int GetSizeOfMaze();

        /// <summary>Gets the name of the player.</summary>
        /// <returns></returns>
        string GetPlayerName();

        /// <summary>Asks for key from user to perform actions.</summary>
        /// <returns></returns>
        ConsoleKey AskForKey();
    }
}
