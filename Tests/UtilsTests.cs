using Core.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void FilterStringInput_EmptyString_ExpectEmptyString()
        {
            var sourceString = string.Empty;

            var resultString = InputFilters.FilterStringInput(sourceString);

            Assert.AreEqual(sourceString, resultString);
        }

        [TestMethod]
        public void FilterStringInput_ContainsSpecialCaracters_ExpectStringWithAlfanumericCharacters()
        {
            var sourceString = "abc09**";
            var expectedResult = "abc09";

            var resultString = InputFilters.FilterStringInput(sourceString);

            Assert.AreEqual(expectedResult, resultString);
        }

        [TestMethod]
        public void ComputeNextRoomId_2X2SizeStartRoom1DirectionS_ExpectResult3()
        {
            var roomId = 1;
            char direction = 's';
            var mazeSize = 2;

            var result = RoomUtil.ComputeNextRoomId(roomId, direction, mazeSize);

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void ComputeNextRoomId_2X2SizeStartRoom1DirectionW_ExpectResult0()
        {
            var roomId = 1;
            char direction = 'w';
            var mazeSize = 2;

            var result = RoomUtil.ComputeNextRoomId(roomId, direction, mazeSize);

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void ComputeNextRoomId_2X2SizeStartRoom1DirectionN_ExpectResultMinus1()
        {
            var roomId = 1;
            char direction = 'n';
            var mazeSize = 2;

            var result = RoomUtil.ComputeNextRoomId(roomId, direction, mazeSize);

            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void ComputeNextRoomId_2X2SizeStartRoom1DirectionE_ExpectResultMinus1()
        {
            var roomId = 1;
            char direction = 'e';
            var mazeSize = 2;

            var result = RoomUtil.ComputeNextRoomId(roomId, direction, mazeSize);

            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void GeneratePseudoRandomNumber_MaxValue10_ExpectLowerThan10()
        {
            var maxValue = 10;

            var result = RoomUtil.GeneratePseudoRandomNumber(maxValue);

            Assert.IsTrue(result < 10);
        }
        
    }
}
