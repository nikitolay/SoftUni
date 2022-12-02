using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        Arena arena;
        Warrior warrior;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new Warrior("Name", 50, 100);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionWhenWarriorIsAlreadyEnrolledForTheFights()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }
        [Test]
        public void EnrollMethodShouldAddWarrior()
        {
            arena.Enroll(warrior);
            Assert.IsTrue(arena.Warriors.Any(x => x.Name == warrior.Name));
        }

        [Test]
        public void FightMethodShouldThrowExceptionWhenТhеAttackerByNameDoesNotExist()
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Name", "second"));
        }
        [Test]
        public void FightMethodShouldThrowExceptionWhenТhеDefenderByNameDoesNotExist()
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("first", "Name"));
        }


        [Test]
        public void CountPropertyShouldReturnWarriorsCount()
        {
            arena.Enroll(warrior);
            for (int i = 0; i < 3; i++)
            {
                arena.Enroll(new Warrior($"{i}", i + 20, i + 30));
            }
            Assert.AreEqual(4, arena.Count);
        }

        [Test]
        public void WarriorsPropertyShouldReturnAllWarriors()
        {
            List<Warrior> listWithWarriors = new List<Warrior>();

            for (int i = 0; i < 3; i++)
            {
                Warrior currWarior = new Warrior($"{i}", i + 20, i + 40);
                arena.Enroll(currWarior);
                listWithWarriors.Add(currWarior);
            }
            CollectionAssert.AreEqual(listWithWarriors, arena.Warriors);
        }

        [Test]
        public void ConstructorShouldInitializeCollectionWithWarriors()
        {
            Assert.NotNull(arena.Warriors);
        }
    }
}
