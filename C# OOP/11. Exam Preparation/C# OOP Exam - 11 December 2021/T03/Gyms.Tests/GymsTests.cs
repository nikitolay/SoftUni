using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Gym gym;
        private Athlete athlete;
        [SetUp]
        public void Initialize()
        {
            gym = new Gym("gym", 2);
            athlete = new Athlete("Name");
        }
        //ctor set valies
        [Test]
        public void NamePropertyShouldReturnValueOfName()
        {
            Assert.AreEqual("gym", gym.Name);
        }

        [Test]
        public void NamePropertyShouldThrowExceptionWhenValueIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(String.Empty, 5));
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 5));
        }

        [Test]
        public void CapacityPropertyShouldReturnValueOfCapacity()
        {
            Assert.AreEqual(2, gym.Capacity);
        }

        [Test]
        public void CapacityPropertyShouldThrowExceptionWhenValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Gym("ime", -1));
        }

        [Test]
        public void CountPropertyShouldReturnAthletesCount()
        {
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void AddAthleteMethodShouldThrowExceptionWhenGymIsFull()
        {
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("some name"));
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("some name")));
        }
        [Test]
        public void AddAthleteMethodShouldAddAthleteInTheCollection()
        {
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void RemoveAthleteMethodShouldThrowExceptionWhenAthleteDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Nencho"));
        }
        [Test]
        public void RemoveAthleteMethodShouldRemoveAthleteFromTheCollection()
        {
            gym.AddAthlete(athlete);
            gym.RemoveAthlete(athlete.FullName);
            Assert.AreEqual(0, gym.Count);
        }
        [Test]
        public void InjureAthleteMethodShouldThrowExceptionWhenAthleteDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Nencho"));

        }
        [Test]
        public void InjureAthleteMethodShouldTSetTrueOnIsInjuredProperty()
        {
            gym.AddAthlete(athlete);
            gym.InjureAthlete(athlete.FullName);
            Assert.True(athlete.IsInjured);

        }
        [Test]
        public void InjureAthleteMethodShouldReturnSuchAthlete()
        {
            gym.AddAthlete(athlete);
            Assert.AreEqual(athlete, gym.InjureAthlete(athlete.FullName));

        }
        [Test]
        public void ReportMethodShouldReturnAllActiveAthletes()
        {
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("Niki"));
            gym.InjureAthlete("Niki");

            string expectedResult = $"Active athletes at {gym.Name}: Name";

            Assert.AreEqual(expectedResult, gym.Report());
        }

    }
}
