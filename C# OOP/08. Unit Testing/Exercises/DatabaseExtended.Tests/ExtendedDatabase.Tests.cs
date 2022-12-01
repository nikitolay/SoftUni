using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
            person = new Person(11, "Nikolay");
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenAlreadyExistPersonWithSameUsername()
        {
            database.Add(person);
            Person secondPerson = new Person(101, "Nikolay");

            Assert.Throws<InvalidOperationException>(() => database.Add(secondPerson));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenAlreadyExistPersonWithSameId()
        {
            database.Add(person);
            Person secondPerson = new Person(11, "Ivan");
            Assert.Throws<InvalidOperationException>(() => database.Add(secondPerson));

        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenThereAreNoPeople()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethodShouldDecreaseCountOfPeople()
        {
            database.Add(person);
            for (int i = 0; i < 3; i++)
            {
                database.Add(new Person(i, i + ""));
            }
            database.Remove();
            Assert.AreEqual(3, database.Count);
        }



    }
}