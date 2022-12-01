using NUnit.Framework;
using System;
using System.Linq;

namespace Database.Tests
{
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [Test]
        public void AddMethodShouldAddElementsWhileCountIsLess16()
        {

            database.Add(10);
            database.Add(12);
            database.Add(8);

            Assert.That(3, Is.EqualTo(database.Count));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenElementsAreAbove16()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void RemoveMethodShouldRemoveElementWhenElementsAreAbove0()
        {
            int[] numbers = Enumerable.Range(1, 10).ToArray();

            database = new Database(numbers);
            database.Remove();
            Assert.AreEqual(9, database.Count);
        }


        [Test]
        public void ConstructorShouldThrowExceptionWhenElementsAreAbove16()
        {
            int[] numbers = Enumerable.Range(1, 17).ToArray();


            Assert.Throws<InvalidOperationException>(() => new Database(numbers));
        }

        [Test]
        public void FetchMethodShouldReturnAllElementsInTheArray()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();

            database = new Database(numbers);
            Assert.AreEqual(numbers, database.Fetch());

        }
    }
}