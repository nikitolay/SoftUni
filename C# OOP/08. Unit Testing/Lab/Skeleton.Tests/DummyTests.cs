using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private const int dummyInitialHealth = 10;
    private const int dummyInitialExpierence = 10;
    private Dummy dummy;
    [SetUp]
    public void TestInit()
    {
        dummy = new Dummy(10, 10);
    }
    [Test]
    public void DummyLosesHealthWhenAttacked()
    {
        dummy.TakeAttack(3);
        Assert.AreEqual(7, dummy.Health, "Dummy doesn't lose health after an atack");
    }

    [Test]
    public void DeadDummyThrowsExceptionWhenAttacked()
    {
        dummy.TakeAttack(10);
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));

    }

    [Test]
    public void DeadDummyCanGiveExperience()
    {
        while (!dummy.IsDead())
        {
            dummy.TakeAttack(1);
        }
        Assert.AreEqual(10, dummy.GiveExperience());
    }

    [Test]
    public void AliveDummyCannotGiveExperience()
    {


        var ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        Assert.That(ex.Message, Is.EqualTo("Target is not dead."));


    }
}