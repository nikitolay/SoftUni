using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Mercedes", "Maybach", 16.8, 200);
        }

        [Test]
        public void ConstructorSetValueOnCarMake()
        {

            Assert.AreEqual("Mercedes", car.Make);

        }
        [Test]
        public void ConstructorSetValueOnCarModel()
        {

            Assert.AreEqual("Maybach", car.Model);
        }
        [Test]
        public void ConstructorSetValueOnCarFuelConsumption()
        {

            Assert.AreEqual(16.8, car.FuelConsumption);
        }
        [Test]
        public void ConstructorSetValueOnCarFuelCapacity()
        {

            Assert.AreEqual(200, car.FuelCapacity);
        }
        [Test]
        public void ConstructorSetDefaultValueOnCarFuelAmount()
        {

            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        public void MakePropertyShouldReturnTheMake()
        {

            Assert.AreEqual("Mercedes", car.Make);
        }

        [Test]
        public void MakePropertyShouldThrowExceptionForNullOrEmptyString()
        {
            Assert.Throws<ArgumentException>(() => new Car("", "Maybach", 16.8, 200));
        }


        [Test]
        public void ModelPropertyShouldReturnTheModel()
        {

            Assert.AreEqual("Maybach", car.Model);
        }

        [Test]
        public void ModelPropertyShouldThrowExceptionForNullOrEmptyString()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "", 16.8, 200));
        }


        [Test]
        public void FuelConsumptionPropertyShouldReturnTheFuelConsumption()
        {

            Assert.AreEqual(16.8, car.FuelConsumption);
        }

        [Test]
        public void FuelConsumptionPropertyShouldThrowExceptionForNegativeFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "Maybach", -16.8, 200));
        }


        [Test]
        public void FuelAmountPropertyShouldReturnTheFuelAmount()
        {
            car.Refuel(200);
            Assert.AreEqual(200, car.FuelAmount);
        }

        [Test]
        public void FuelAmountPropertyShouldThrowExceptionForNegativeFuelAmount()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(-500));
        }

        [Test]
        public void FuelCapacityPropertyShouldReturnTheFuelCapacity()
        {
            Assert.AreEqual(200, car.FuelCapacity);
        }

        [Test]
        public void FuelCapacityPropertyShouldThrowExceptionForNegativeFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "Maybach", 16.8, -200));
        }



        [Test]
        public void RefuelMethodShouldThrowExceptionForNegativeFuel()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(-100));
        }

        [Test]
        public void RefuelMethodShouldAddFuelToFuelAmount()
        {
            car.Refuel(10);
            Assert.AreEqual(10, car.FuelAmount);
        }
        [Test]
        public void RefuelMethodShouldSetValueOfFuelCapacityOnFuelAmountIfAmountIsGreaterThanCapacity()
        {
            car.Refuel(210);
            Assert.AreEqual(200, car.FuelAmount);
        }


        [Test]
        public void DriveMethodShouldThrowExceptionIfFuelNeededIsGreaterThanFuelAmount()
        {
            car.Refuel(99);

            Assert.Throws<InvalidOperationException>(() => car.Drive(2000));
        }

        [Test]
        public void DriveMethodShouldDecreaseFuelAmountWithFuelNeeded()
        {
            car.Refuel(100);
            car.Drive(99);

            Assert.AreEqual(83.367999999999995d, car.FuelAmount);
        }
    }
}