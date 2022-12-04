namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStockTests
    {
        private Product product;
        private ProductStock products;
        private IProduct secondProduct;
        [SetUp]
        public void Initialize()
        {
            product = new Product("test", 3, 3);
            secondProduct = new Product("test2", 3, 3);

            products = new ProductStock();
            products.Add(product);
        }

        [Test]
        public void IndexerShouldReturnProductOnGivenIndex()
        {
            IProduct currProduct = products[0];
            Assert.AreEqual(product, currProduct);
        }

        [Test]
        public void IndexerShouldSetProductOnGivenIndex()
        {
            products.Add(secondProduct);
            Assert.AreEqual(secondProduct, products[1]);
        }

        [Test]
        public void CountPropertyShouldReturnCountOfProducts()
        {
            products.Add(secondProduct);
            Assert.AreEqual(2, products.Count);
        }

        [Test]
        public void AddMethodShouldAddProduct()
        {
            Assert.True(products.Contains(product));
        }

        [Test]
        public void AddMethodShouldNotAddTheDuplicateProduct()
        {
            products.Add(product);
            products.Add(product);
            Assert.AreEqual(1, products.Count);
        }


        [Test]
        public void ConstainsMethodShouldReturnTrueIfGivenProductAlreadyExist()
        {
            Assert.True(products.Contains(product));
        }
        [Test]
        public void ConstainsMethodShouldReturnFalseIfGivenProductDoesNotExist()
        {

            Assert.False(products.Contains(secondProduct));
        }
        [Test]
        public void FindMethodShouldReturnProductOnGivenIndex()
        {
            Assert.AreEqual(product, products.Find(0));
        }

        [TestCase(1)]
        [TestCase(-1)]
        public void FindMethodShouldThrowExceptionWhenIndexOutOfRange(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => products.Find(index));
        }

        [Test]
        public void FindAllByPriceMethodShouldReturnEmptyCollectionWhenNoneFound()
        {
            int countOfProduct = products.FindAllByPrice(123.68).Count();
            Assert.AreEqual(0, countOfProduct);
        }
        [Test]
        public void FindAllByPriceMethodShouldReturnNewCollectionWithFilteredProductsWithGivenPrice()
        {
            products.Add(secondProduct);
            int countOfProduct = products.FindAllByPrice(3).Count();
            Assert.AreEqual(2, countOfProduct);
        }

        [Test]
        public void FindAllByQuantityMethodShouldReturnEmptyCollectionWhenNoneFound()
        {
            int countOfProduct = products.FindAllByQuantity(500).Count();
            Assert.AreEqual(0, countOfProduct);
        }
        [Test]
        public void FindAllByQuantityMethodShouldReturnNewCollectionWithFilteredProductsWithGivenQuantity()
        {
            products.Add(secondProduct);
            int countOfProduct = products.FindAllByQuantity(3).Count();
            Assert.AreEqual(2, countOfProduct);
        }



        [Test]
        public void FindAllInRangeMethodShouldReturnEmptyCollectionWhenNoneFound()
        {
            int countOfProduct = products.FindAllInRange(500, 1000).Count();
            Assert.AreEqual(0, countOfProduct);
        }
        [Test]
        public void FindAllInRangeMethodShouldReturnNewCollectionWithFilteredProductsWhosePriceIsInGivenRange()
        {
            products.Add(secondProduct);
            IProduct currentProduct = new Product("test3", 33, 3);
            products.Add(currentProduct);
            int countOfProduct = products.FindAllInRange(3, 33).Count();
            Assert.AreEqual(3, countOfProduct);
        }

        [Test]
        public void FindByLabelMethodShouldWorkCorrectly()
        {
            IProduct currentProduct = products.FindByLabel("test");
            Assert.AreEqual(product, currentProduct);
        }
        [Test]
        public void FindByLabelMethodShouldThrowExceptionWhenGivenProductDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => products.FindByLabel("test3333"));
        }

        [Test]
        public void FindMostExpensiveProductMethodShouldWorkCorrectly()
        {
            IProduct currentProduct = new Product("mostExpensive", 333, 3);
            products.Add(currentProduct);
            IProduct mostExpensiveProduct = products.FindMostExpensiveProduct();
            Assert.AreEqual(currentProduct, mostExpensiveProduct);
        }

        [Test]
        public void RemoveMethodShouldReturnTrueIfAGivenProductHasBeenRemoved()
        {
            Assert.True(products.Remove(product));

        }

        [Test]
        public void RemoveMethodShouldReturnFalseIfAGivenProductHasNotBeenRemoved()
        {
            Assert.False(products.Remove(secondProduct));
        }

        [Test]
        public void GetEnumeratorMethodShouldWorkCorrectly()
        {
            products.Add(secondProduct);
            List<IProduct> expectedResult = new List<IProduct>() { product, secondProduct };
            CollectionAssert.AreEqual(expectedResult, products.ToList());
        }
    }
}
