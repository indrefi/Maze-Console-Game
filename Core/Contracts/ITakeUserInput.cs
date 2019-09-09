using System;

namespace Core.Contracts
{
    public interface ITakeUserInput
    {
        /// <summary>Gets the input from the user.</summary>
        /// <returns></returns>
        string GetLine();

        /// <summary>Gets the key.</summary>
        /// <returns></returns>
        ConsoleKey GetKey();
    }
}