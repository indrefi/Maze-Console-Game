using Autofac.Extras.Moq;
using Core.Contracts;
using Core.Models;
using Core.Services;
using Core.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class MazeIntegrationServiceTests
    {
        private List<Room> _rooms;
        private MazeMap _mazeMap;
        private readonly int _sizeOfMaze = 2;
        private readonly int _numberOfRooms = 2 * 2;
        private readonly int _numberOfTraps = 1;
        private readonly int _trapRoom = 1;
        private readonly int _treasureRoom = 2;
        private readonly int _entranceRoom = 0;

        [TestInitialize]
        public void Setup()
        {
            _rooms = new List<Room>
                {
                    new Room
                    {
                        Id = 0,
                        IsEntrance = true,
                        IsVisited = true,
                        HasTreasure = false,
                        HasTrap = false,
                        X = 0,
                        Y = 0,
                        Description = Constants.RoomConstants.EntranceRoomDescription
                    },
                    new Room
                    {
                        Id = 1,
                        IsEntrance = false,
                        IsVisited = false,
                        HasTreasure = false,
                        HasTrap = true,
                        X = 0,
                        Y = 1,
                        Description = Constants.RoomConstants.TrapRoomDescription
                    },
                    new Room
                    {
                        Id = 2,
                        IsEntrance = false,
                        IsVisited = false,
                        HasTreasure = true,
                        HasTrap = false,
                        X = 1,
                        Y = 0,
                        Description = Constants.RoomConstants.TreasureRoomDescription
                    },
                    new Room
                    {
                        Id = 3,
                        IsEntrance = false,
                        IsVisited = false,
                        HasTreasure = false,
                        HasTrap = false,
                        X = 1,
                        Y = 1,
                        Description = Constants.RoomConstants.NormalRoomDescription
                    },
                };

            _mazeMap = new MazeMap
            {
                mazeRooms = _rooms,
                mazeSize = _sizeOfMaze
            };
        }

        [TestMethod]
        public void CausesInjury_TrapRoomId_ExpectedTrue()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Mock<IBuildMaze> mockBuildMaze = new Mock<IBuildMaze>();
                Mock<ILoadMaze> mockLoadMaze = new Mock<ILoadMaze>();
                mockLoadMaze.Setup(o => o.GetMazeMapInstance()).Returns(_mazeMap);

                var mazeIntegration = new MazeIntegrationService(mockBuildMaze.Object, mockLoadMaze.Object);

                Assert.IsTrue(mazeIntegration.CausesInjury(_trapRoom));
            }
        }

        [TestMethod]
        public void CausesInjury_EntranceRoomId_ExpectedFalse()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Mock<IBuildMaze> mockBuildMaze = new Mock<IBuildMaze>();
                Mock<ILoadMaze> mockLoadMaze = new Mock<ILoadMaze>();
                mockLoadMaze.Setup(o => o.GetMazeMapInstance()).Returns(_mazeMap);

                var mazeIntegration = new MazeIntegrationService(mockBuildMaze.Object, mockLoadMaze.Object);

                Assert.IsFalse(mazeIntegration.CausesInjury(_entranceRoom));
            }
        }

        [TestMethod]
        public void GetDescription_EntranceRoomId_ExpectedEntranceRoomDescription()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var expectedDescription = Constants.RoomConstants.EntranceRoomDescription;
                Mock<IBuildMaze> mockBuildMaze = new Mock<IBuildMaze>();
                Mock<ILoadMaze> mockLoadMaze = new Mock<ILoadMaze>();
                mockLoadMaze.Setup(o => o.GetMazeMapInstance()).Returns(_mazeMap);

                var mazeIntegration = new MazeIntegrationService(mockBuildMaze.Object, mockLoadMaze.Object);

                Assert.AreEqual(mazeIntegration.GetDescription(_entranceRoom), expectedDescription);
            }
        }

        [TestMethod]
        public void HasTreasure_TreasureRoomId_ExpectedTrue()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Mock<IBuildMaze> mockBuildMaze = new Mock<IBuildMaze>();
                Mock<ILoadMaze> mockLoadMaze = new Mock<ILoadMaze>();
                mockLoadMaze.Setup(o => o.GetMazeMapInstance()).Returns(_mazeMap);

                var mazeIntegration = new MazeIntegrationService(mockBuildMaze.Object, mockLoadMaze.Object);

                Assert.IsTrue(mazeIntegration.HasTreasure(_treasureRoom));
            }
        }

        [TestMethod]
        public void GetEntranceRoom_EntranceRoomId_ExpectedEntranceRoomId()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Mock<IBuildMaze> mockBuildMaze = new Mock<IBuildMaze>();
                Mock<ILoadMaze> mockLoadMaze = new Mock<ILoadMaze>();
                mockLoadMaze.Setup(o => o.GetMazeMapInstance()).Returns(_mazeMap);

                var mazeIntegration = new MazeIntegrationService(mockBuildMaze.Object, mockLoadMaze.Object);

                Assert.AreEqual(mazeIntegration.GetEntranceRoom(), _entranceRoom);
            }
        }

        [TestMethod]
        public void GetRoom_Start0_ExpectedEnd2()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var startRoom = 0;
                var endRoom = 2;
                var direction = 's';

                Mock<IBuildMaze> mockBuildMaze = new Mock<IBuildMaze>();
                Mock<ILoadMaze> mockLoadMaze = new Mock<ILoadMaze>();
                mockLoadMaze.Setup(o => o.GetMazeMapInstance()).Returns(_mazeMap);

                var mazeIntegration = new MazeIntegrationService(mockBuildMaze.Object, mockLoadMaze.Object);

                Assert.AreEqual(mazeIntegration.GetRoom(startRoom,direction), endRoom);
            }
        }
    }
}
