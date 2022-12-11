using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robots.Tests
{
    [TestFixture]
    public class RobotManagerTests
    {
        RobotManager robotManager;
        Robot robotOne;
        Robot robotTwo;
        [SetUp]
        public void Initialize()
        {
            robotManager = new RobotManager(3);
            robotOne = new Robot("Nikolay", 100);
            robotTwo = new Robot("Mario", 37);
        }

        [Test]
        public void ConstructorShouldSetValueOfCapacityProperty()
        {
            RobotManager robotManager = new RobotManager(5);
            Assert.AreEqual(5, robotManager.Capacity);
        }
        [Test]
        public void ConstructorShouldInitializeCollectionOfRobots()
        {
            RobotManager robotManager = new RobotManager(5);
            Assert.AreEqual(0, robotManager.Count);
        }
        [Test]
        public void PropertyCapacityShouldReturnValueOfCapacity()
        {
            Assert.AreEqual(3, robotManager.Capacity);
        }
        [Test]
        public void PropertyCapacityShouldThrowExceptionWhenValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-50));
        }

        [Test]
        public void PropertyCountShouldReturnCountOfRobots()
        {
            robotManager.Add(robotOne);
            robotManager.Add(robotTwo);
            Assert.AreEqual(2, robotManager.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenAlreadyExistRobotWithSameName()
        {
            robotManager.Add(robotOne);
            robotManager.Add(robotTwo);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robotOne));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenNotEnoughCapacity()
        {
            robotManager.Add(robotOne);
            robotManager.Add(robotTwo);
            Robot robot = new Robot("Ivan", 20);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Name", 55)));
        }
        [Test]
        public void AddMethodShouldAddRobotInTheCollection()
        {
            robotManager.Add(robotOne);
            robotManager.Add(robotTwo);
            Assert.AreEqual(2, robotManager.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenRobotWithGivenNameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Niki"));
        }
        [Test]
        public void RemoveMethodShouldRemoveRobotFromTheCollection()
        {
            robotManager.Add(robotOne);
            robotManager.Add(robotTwo);
            robotManager.Remove(robotOne.Name);
            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void WorkMethodShouldThrowExceptionWhenRobotWithGivenNameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Niki", "job", 25));
        }

        [Test]
        public void WorkMethodShouldThrowExceptionWhenDoesNotHaveEnoughBattery()
        {
            robotManager.Add(robotOne);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robotOne.Name, "job", 150));
        }


        [Test]
        public void WorkMethodShouldDecreaseRobotBatteryWithBatteryUsage()
        {
            robotManager.Add(robotOne);
            robotManager.Work(robotOne.Name, "job", 23);
            Assert.AreEqual(77, robotOne.Battery);
        }

        [Test]
        public void ChargeMethodShouldThrowExceptionWhenRobotWithGivenNameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Niki"));
        }

        [Test]
        public void ChargeMethodShouldChangeValueOfBatteryOnTheValueOfMaximumBattery()
        {
            robotManager.Add(robotOne);
            robotManager.Work("Nikolay", "job", 99);
            robotManager.Charge("Nikolay");

            Assert.AreEqual(100, robotOne.Battery);

        }
    }
}
