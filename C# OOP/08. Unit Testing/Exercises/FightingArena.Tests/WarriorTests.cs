using FightingArena;
using NUnit.Framework;
using System;
using System.ComponentModel;

namespace Tests
{
    public class WarriorTests
    {
        Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Ivan", 50, 100);
        }

        [Test]
        public void NamePropertyShouldThrowExceptionWhenValueIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 50, 100));
        }


        [Test]
        public void NamePropertyShouldThrowExceptionWhenValueIsWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 50, 100));
        }

        [Test]
        public void NamePropertyShouldSetValueOnName()
        {

            Assert.AreEqual("Ivan", warrior.Name);
        }
        [Test]
        public void NamePropertyShouldReturnValueOfName()
        {

            Assert.AreEqual("Ivan", warrior.Name);
        }

        [Test]
        public void DamagePropertyShouldThrowExceptionWhenGivenDamageIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", -50, 100));
        }
        [Test]
        public void DamagePropertyShouldSetValueOnDamage()
        {
            Assert.AreEqual(50, warrior.Damage);
        }
        [Test]
        public void DamagePropertyShouldReturnValueOfDamage()
        {
            Assert.AreEqual(50, warrior.Damage);
        }

        [Test]
        public void HpPropertyShouldThrowExceptionWhenGivenHpIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", 50, -100));
        }

        [Test]
        public void HpPropertyShouldSetValueOnHp()
        {
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void HpPropertyShouldReturnValueOfHp()
        {
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void AttackMethodShouldThrowExceptionWhenHpIsLessThanToMinHp()
        {
            warrior = new Warrior("Ivan", 30, 29);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior));
        }
        [Test]
        public void AttackMethodShouldThrowExceptionWhenHpIsEqualToMinHp()
        {
            warrior = new Warrior("Ivan", 30, 30);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionWhenHpOfOpponentIsLessThanToMinHp()
        {

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Ivan", 30, 29)));
        }
        [Test]
        public void AttackMethodShouldThrowExceptionWhenHpOfOpponentIsLEqualToMinHp()
        {

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Ivan", 30, 30)));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionWhenHpIsLessThanToOpponentDamage()
        {

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Ivan", 101, 29)));
        }

        [Test]
        public void AttackMethodShouldDecreaseHpWithTheOpponentDamage()
        {
            Warrior opponent = new Warrior("name", 20, 100);
            warrior.Attack(opponent);
            Assert.AreEqual(80, warrior.HP);
        }

        [Test]
        public void AttackMethodShouldSetNullOnOpponentHpWhenAttackingDamageIsGreaterThanToOpponentHp()
        {
            Warrior opponent = new Warrior("name", 20, 40);
            warrior.Attack(opponent);
            Assert.AreEqual(0, opponent.HP);
        }
        [Test]
        public void AttackMethodShouldDecreaseOpponentHpWithAttackingDamage()
        {
            Warrior opponent = new Warrior("name", 20, 60);
            warrior.Attack(opponent);
            Assert.AreEqual(10, opponent.HP);
        }
        [Test]
        public void ConstructorShouldSetValueOfHp()
        {
            Assert.AreEqual(100, warrior.HP);
        }
        [Test]
        public void ConstructorShouldSetValueOfDamage()
        {
            Assert.AreEqual(50, warrior.Damage);
        }
        [Test]
        public void ConstructorShouldSetValueOfName()
        {
            Assert.AreEqual("Ivan", warrior.Name);
        }
    }
}