namespace Robots.Tests
{
    using NUnit.Framework;
    using System;


    [TestFixture]
    public class RobotsTests
    {
        Robot robot;
        [SetUp]
        public void Initialize()
        {
            robot = new Robot("Nikolay", 100);
        }

        [Test]
        public void ConstructorShouldSetValueOnNameProperty()
        {
            Assert.AreEqual("Nikolay", robot.Name);
        }

        [Test]
        public void ConstructorShouldSetValueOnMaximumBatteryProperty()
        {
            Assert.AreEqual(100, robot.MaximumBattery);
        }
        [Test]
        public void ConstructorShouldSetValueOnBatteryProperty()
        {
            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void PropertyNameShouldSetValueOfName()
        {
            robot.Name = "Mario";
            Assert.AreEqual("Mario", robot.Name);
        }
        [Test]
        public void PropertyBatteryShouldReturnValueOfName()
        {
            robot.Battery = 63;
            Assert.AreEqual(63, robot.Battery);
        }


    }
}
