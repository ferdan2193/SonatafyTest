using SonatafyTest;
using SonatafyTest.Helpers;
using System.Drawing;
using SonatafyTest.Models;

namespace SonatafyTestValidation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        [TestCase("4, 4 4")]
        [TestCase("4, 4 44")]
        [TestCase("4 4s")]
        [TestCase("4, n")]
        public void InValid_Exploration_Limit(string explorationLimitInvalid)
        {
            bool isValid = InputValidator.convertToExplorationPointLimit(explorationLimitInvalid,out _);
            Assert.AreEqual(isValid, false);
        }


        [Test]
        [TestCase("4 4")]
        [TestCase("4 5")]
        [TestCase("5 20")]
        public void Valid_Exploration_Limit(string explorationLimitValid)
        {
            bool isValid = InputValidator.convertToExplorationPointLimit(explorationLimitValid, out _);
            Assert.AreEqual(isValid, true);
        }

        [Test]
        [TestCase("5 20n")]
        [TestCase("5 20 ,")]
        [TestCase("5 e 20")]
        [TestCase("n n 10")]
        public void Invalid_Initial_Point(string initialPointInvalid)
        {
            bool isValid = InputValidator.initialPointValidation(initialPointInvalid, out _);
            Assert.AreEqual(isValid, false);
        }

        [Test]
        [TestCase("5 5 N")]
        [TestCase("5 3 S")]
        public void Valid_Initial_Point(string initialPointValid)
        {
            bool isValid = InputValidator.initialPointValidation(initialPointValid, out _);
            Assert.AreEqual(isValid, true);
        }

        [Test]
        [TestCase("LMRL 3ELD")]
        [TestCase("LMLRMLMLR")]
        public void ValidInstructions(string instructionsValid)
        {
            bool isValid = InputValidator.validateInstructions(instructionsValid, out _);
            Assert.AreEqual(isValid, true);
        }

        [Test]
        [TestCase("")]
        [TestCase("3ew2")]
        public void InvalidInstructions(string instructionsInvalid)
        {
            bool isValid = InputValidator.validateInstructions(instructionsInvalid, out _);
            Assert.AreEqual(isValid, false);
        }

        [Test]
        [TestCase("1 2 n", "LMLMLMLMM")]
        public void ValidSystem(string initialPointValid, string instructionsValid)
        {
            Point explorationLimit = new Point(20, 20);
            InitialPoint initialPoint = new InitialPoint();
            InputValidator.initialPointValidation(initialPointValid, out initialPoint);
            Rover rover = new Rover(initialPoint, instructionsValid);
            List<Rover> rovers = new List<Rover>();
            rovers.Add(rover);
            MarsRovers marsRoversSystem = new MarsRovers(explorationLimit, rovers);
            List<string> listRovers = marsRoversSystem.ExecuteInstructions();
            Assert.AreEqual(listRovers[0], "1 3 N");
        }

        [Test]
        [TestCase("3 3 e", "MMRMMRMRRM")]
        public void Validation_System_Instructions_Output_2(string initialPointValid, string instructionsValid)
        {
            Point explorationLimit = new Point(20, 20);
            InitialPoint initialPoint = new InitialPoint();
            InputValidator.initialPointValidation(initialPointValid, out initialPoint);
            Rover rover = new Rover(initialPoint, instructionsValid);
            List<Rover> rovers = new List<Rover>();
            rovers.Add(rover);
            MarsRovers marsRoversSystem = new MarsRovers(explorationLimit, rovers);
            List<string> listRovers = marsRoversSystem.ExecuteInstructions();
            Assert.AreEqual(listRovers[0], "5 1 E");
        }

    }
}