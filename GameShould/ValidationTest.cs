﻿using ToyRobot;
using Telerik.JustMock;

namespace ToyRobotTests
{
    public class ValidationTest
    {
        private Validation validation;
        private IPlay mockedBoard;

        [SetUp]
        public void Setup()
        {
            validation = new Validation();
            mockedBoard = Mock.Create<IPlay>();
        }

        [Test]
        public void validate_location()
        {
            Boolean validCommand0 = validation.validateLocation(Data.validRow(), Data.validCol(), Data.validDirection());
            Boolean validCommand1 = validation.validateLocation(Data.validRow(), Data.validCol(), Data.invalidDirection());
            Boolean validCommand2 = validation.validateLocation(Data.invalidRow(), Data.validCol(), Data.validDirection());

            Assert.IsTrue(validCommand0);
            Assert.IsFalse(validCommand1);
            Assert.IsFalse(validCommand2);
        }

        [Test]
        public void validate_coordinate()
        {
            Boolean validCoordinate0 = validation.validateCoordinate(Data.validRow(), Data.validCol());
            Boolean validCoordinate1 = validation.validateCoordinate(Data.invalidRow(), Data.validCol());

            Assert.IsTrue(validCoordinate0);
            Assert.IsFalse(validCoordinate1);
        }

        [Test]
        public void validate_if_the_location_is_not_occupied()
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            Coordinate coordinate = new Coordinate(Data.validCol(), Data.validRow());
            Mock.Arrange(() => mockedBoard.Items).Returns(coordinates);

            Boolean isOccupiedLocation = validation.isOccupiedCoordinate(coordinate, mockedBoard);

            Assert.IsFalse(isOccupiedLocation);
        }

        [Test]
        public void validate_if_the_location_is_occupied()
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            Coordinate coordinate = new Coordinate(Data.validCol(), Data.validRow());
            coordinates.Add(coordinate);
            Mock.Arrange(() => mockedBoard.Items).Returns(coordinates);

            Boolean isOccupiedLocation = validation.isOccupiedCoordinate(coordinate, mockedBoard);

            Assert.IsTrue(isOccupiedLocation);
        }

        //Static Mocking, Elevated Feature
        [Test]
        public void validate_if_there_is_a_robot_on_the_board()
        {
            Coordinate coordinate = new Coordinate(Data.validCol(), Data.validRow());
            ICardinal cardinal = new North();
            Mock.Arrange(() => mockedBoard.Robot).Returns(Robot.getInstance(coordinate, cardinal));

            Boolean isRobot = validation.isRobot(mockedBoard);

            Assert.IsTrue(isRobot);
        }

        //Static Mocking, Elevated Feature
        [Test]
        public void validate_if_there_is_not_a_robot_on_the_board()
        {
            Boolean isRobot = validation.isRobot(mockedBoard);

            Assert.IsFalse(isRobot);
        }
    }
}
