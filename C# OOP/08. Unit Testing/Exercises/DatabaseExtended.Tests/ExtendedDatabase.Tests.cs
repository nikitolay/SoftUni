using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Linq;

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

        [Test]
        public void FindByUsernameMethodShouldReturnTheWantedPerson()
        {
            database.Add(person);
            Assert.AreEqual(person, database.FindByUsername(person.UserName));
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionWhenReceivedNull()
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }
        [Test]
        public void FindByUsernameMethodShouldThrowExceptionWhenReceivedEmptyText()
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(string.Empty));
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionWhenAGivenUserNotContainedInDatabase()
        {


            Person personTwo = new Person(15, "Ivan");

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(personTwo.UserName));
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionWhenTheCaseHasBeenReplaced()
        {

            database.Add(person);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("nikolay"));
        }

        [Test]
        public void FindByIdMethodShouldReturnTheWantedPerson()
        {
            database.Add(person);
            Assert.AreEqual(person, database.FindById(person.Id));
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionWhenNotContainedUserWithSameId()
        {

            Assert.Throws<InvalidOperationException>(() => database.FindById(11));
        }
        [Test]
        public void FindByIdMethodShouldThrowExceptionWhenANegativeNumberIsEntered()
        {

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-200));
        }
        [Test]
        public void ConstructorShouldAddAllElementsInTheArray()
        {
            Person[] persons=new Person[3];
            for (int i = 0; i < 3; i++)
            {
                persons[i] = new Person(i,$"{i}");
            }
            database = new ExtendedDatabase.ExtendedDatabase(persons);
            Assert.AreEqual(persons.Length, database.Count);
        }
    }
}