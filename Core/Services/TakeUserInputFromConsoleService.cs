using Core.Contracts;
using System;

namespace Core.Services
{
    public class TakeUserInputFromConsoleService : ITakeUserInput
    {
        public ConsoleKey GetKey()
        {
            return Console.ReadKey().Key;
        }

        public string GetLine()
        {
            return Console.ReadLine();
        }
    }
}
