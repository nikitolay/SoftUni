using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;
            private Weapon weapon;
            [SetUp]
            public void Initialize()
            {
                planet = new Planet("Planet", 12);
                weapon = new Weapon("Name", 150, 4);
            }
            //ctor set value
            [Test]
            public void NamePropertyShouldReturnValueOfName()
            {
                Assert.AreEqual("Planet", planet.Name);
            }
            [Test]
            public void NamePropertyShouldThrowExceptionWhenValueIsNullOrEmpty()
            {
                Assert.Throws<ArgumentException>(() => new Planet(string.Empty, 15));
                Assert.Throws<ArgumentException>(() => new Planet(null, 15));
            }

            [Test]
            public void BudgetPropertyShouldReturnValueOfBudget()
            {
                Assert.AreEqual(12, planet.Budget);
            }
            [Test]
            public void BudgetPropertyShouldThrowExceptionWhenValueIsNegative()
            {
                Assert.Throws<ArgumentException>(() => new Planet("name", -5));
            }

            [Test]
            public void WeaponsPropertyShouldReturnAllWeapons()
            {
                planet.AddWeapon(weapon);
                List<Weapon> expected = new List<Weapon> { weapon };
                CollectionAssert.AreEqual(expected, planet.Weapons);
            }
            [Test]
            public void MilitaryPowerRatioPropertyShouldReturnSumOfDestructionLevelOnWeapons()
            {
                planet.AddWeapon(weapon);
                planet.AddWeapon(new Weapon("SOME NAME", 55, 3));
                Assert.AreEqual(7, planet.MilitaryPowerRatio);
            }
            [Test]
            public void ProfitMethodShouldIncreaseBudgetWithGivenAmount()
            {
                planet.Profit(50);
                planet.Profit(33);
                Assert.AreEqual(95, planet.Budget);
            }
            [Test]
            public void SpendFundsMethodShouldThrowExceptionWhenGivenAmountIsGreaterThanBudget()
            {
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(13));
            }
            [Test]
            public void SpendFundsMethodShouldDecreaseBudgetWithAmount()
            {
                planet.AddWeapon(weapon);
                planet.SpendFunds(3);
                Assert.AreEqual(9, planet.Budget);
            }
            [Test]
            public void AddWeaponMethodShouldThrowExceptionWhenGivenWeaponIsAlreadyExist()
            {
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
            }
            [Test]
            public void AddWeaponMethodShouldAddWeaponInTheCollecton()
            {
                planet.AddWeapon(weapon);
                Assert.True(planet.Weapons.Contains(weapon));
            }

            [Test]
            public void RemoveWeaponMethodShouldRemoveWeaponFromTheCollectio()
            {
                planet.AddWeapon(weapon);
                planet.RemoveWeapon(weapon.Name);
                Assert.AreEqual(0, planet.Weapons.Count);
            }
            [Test]
            public void UpgradeWeaponMethodShouldThrowExceptioWhenGivenWeaponDoesNotExistInTheColletion()
            {
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("mario"));
            }
            [Test]
            public void UpgradeWeaponMethodShouldIncreaseDestructionLevel()
            {
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);
                Assert.AreEqual(5, weapon.DestructionLevel);
            }
            [Test]
            public void DestructOpponentMethodShouldThrowExceptionWhenOpponentMilitaryPowerRatioIsEqualOrGreaerThanThisMilitaryPowerRatio()
            {
                planet.AddWeapon(weapon);
                Planet opponent = new Planet("Some name", 120);
                opponent.AddWeapon(new Weapon("name", 6, 6));
                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(opponent));
            }
            [Test]
            public void DestructOpponentMethodShouldReturnStringWithInfoWhoPlanetIsDestructed()
            {
                planet.AddWeapon(weapon);
                Planet opponent = new Planet("Some name", 120);
                opponent.AddWeapon(new Weapon("name", 6, 3));
                string expected = $"{opponent.Name} is destructed!";
                Assert.AreEqual(expected, planet.DestructOpponent(opponent));
            }
        }
    }
}
