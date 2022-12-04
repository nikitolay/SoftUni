namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        [Test]
        public void ValidateTheConstructor()
        {
            IProduct product = new Product("testProduct", 4, 5);

            Assert.That(product.Label, Is.EqualTo("testProduct"));
            Assert.That(product.Price, Is.EqualTo(4));
            Assert.That(product.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void TheNameOfProductShouldNotBeNullOrEmpty()
        {
            Assert.That(() => new Product(string.Empty, 2, 5), Throws.ArgumentException.With.Message.EqualTo("The name of product should not be null"));
        }

        [Test]
        public void ThePriceOfProductShouldNotBeZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product("test", 0, 5), "The price can not be zero");
        }

        [Test]
        public void ThePriceOfProductShouldNotBeNegativeNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product("test", -20, 5), "The price can not be negative number");
        }

        [Test]
        public void TheQuantifyShouldNotBeNegativeNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product("test", 5, -20), "The quantity can not be negative number");
        }

    }
}