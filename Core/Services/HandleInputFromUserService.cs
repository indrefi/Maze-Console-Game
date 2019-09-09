using Core.Contracts;
using Core.Utils;
using System;

namespace Core.Services
{
    public class HandleInputFromUserService : IHandleInput
    {
        private readonly ITakeUserInput _userInput;

        public HandleInputFromUserService(ITakeUserInput userInput)
        {
            _userInput = userInput;
        }

        public ConsoleKey AskForKey()
        {
            return _userInput.GetKey();
        }

        public int GetSizeOfMaze()
        {
            int rooms = 0;

            while (rooms <= 1)
            {
                Console.WriteLine("Insert the number of desired rooms. Number must be greater then 1.");
                var numberOfRooms = _userInput.GetLine();
                int.TryParse(numberOfRooms, out rooms);
            }

            return rooms;
        }

        public string GetPlayerName()
        {
            Console.WriteLine("Insert the name of the Player");
            var nameOfPlayer = InputFilters.FilterStringInput(_userInput.GetLine());

            return nameOfPlayer;
        }
    }
}
