using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    public class ChainBlockTests
    {
        private IChainBlock chainblock;
        private ITransaction transaction;
        private ITransaction secondTransaction;
        private ITransaction thirdTransaction;
        [SetUp]
        public void Initialize()
        {
            chainblock = new ChainBlock();
            transaction = new Transaction
            {
                Id = 12345,
                From = "Stoyan",
                To = "Joro",
                Amount = 100,
                Status = TransactionStatus.Successfull
            };
            secondTransaction = new Transaction
            {
                Id = 3333,
                From = "Stoyan",
                To = "Joro",
                Amount = 50,
                Status = TransactionStatus.Successfull
            };
            thirdTransaction = new Transaction
            {
                Id = 33335,
                From = "Stoyan",
                To = "Pepi",
                Amount = 123,
                Status = TransactionStatus.Unauthorized
            };
        }

        [Test]
        public void AddMethodShouldAddTransactions()
        {
            //Act
            chainblock.Add(transaction);

            //Assert
            bool exist = chainblock.Contains(transaction);
            Assert.IsTrue(exist);
            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]
        public void AddMethodShouldAddUniqueRecords()
        {
            //Arrange

            ITransaction duplicatedTransaction = new Transaction
            {
                Id = 12345,
                From = "Stoyan",
                To = "Joro",
                Amount = 100,
                Status = TransactionStatus.Successfull
            };

            //Act
            chainblock.Add(transaction);
            chainblock.Add(duplicatedTransaction);

            //Assert
            bool transactionExist = chainblock.Contains(transaction);
            int expectedCount = 1;

            Assert.IsTrue(transactionExist);
            Assert.AreEqual(expectedCount, chainblock.Count);
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeTransactionStatus()
        {
            //Arrange
            chainblock.Add(transaction);

            //Act
            chainblock.ChangeTransactionStatus(transaction.Id, TransactionStatus.Unauthorized);

            //Assert
            ITransaction chainblockTransaction = chainblock.GetById(transaction.Id);
            Assert.AreEqual(TransactionStatus.Unauthorized, chainblockTransaction.Status);
        }
        [Test]
        public void ChangeTransactionStatusShouldThrowExceptionWhenGivenTransactionDoesNotExist()
        {
            //Act & Assert
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(0000, TransactionStatus.Unauthorized));
        }

        [Test]
        public void RemoveTransactionByIdShouldRemoveTransactionIfIdExist()
        {
            //Arrange
            chainblock.Add(transaction);

            //Act
            chainblock.RemoveTransactionById(transaction.Id);

            //Assert
            Assert.AreEqual(0, chainblock.Count);
        }
        [Test]
        public void RemoveTransactionByIdShouldThrowExceptionIfIdDoesNotExist()
        {

            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(0000));
        }

        [Test]
        public void GetByIdShouldReturnTransactionIfIdExist()
        {
            //Arrange
            chainblock.Add(transaction);
            //Act
            ITransaction theSameTransactionD = chainblock.GetById(transaction.Id);

            //Assert
            Assert.AreEqual(transaction, theSameTransactionD);
        }
        [Test]
        public void GetByIdShouldThrowExceptionIfIdDoesNotExist()
        {
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(0000));
        }
        [Test]
        public void GetByTransactionStatusReturnTransactionsWithGivenStatusOrderedByAmountDescending()
        {
            //Arrange
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            //Act
            IEnumerable<ITransaction> transactions = chainblock.GetByTransactionStatus(TransactionStatus.Successfull);
            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction> { transaction, secondTransaction };
            //Assert
            CollectionAssert.AreEqual(expectedTransactions, transactions);
        }
        [Test]
        public void GetByTransactionStatusThrowExceptionWhenDoesNotExistTransactionsWithSuchStatus()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldWorkCorrectly()
        {
            //Arrange
            chainblock.Add(transaction);

            chainblock.Add(secondTransaction);

            chainblock.Add(thirdTransaction);
            ITransaction transactionWithDifferentSender = new Transaction
            {
                Id = 1111,
                From = "Nencho",
                To = "Pepi",
                Amount = 1000,
                Status = TransactionStatus.Successfull
            };
            chainblock.Add(transactionWithDifferentSender);

            //Act
            IEnumerable<string> expectedSender = new List<string> { "Stoyan", "Stoyan", "Nencho" };
            IEnumerable<string> resultSenders = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            //Assert
            CollectionAssert.AreEqual(expectedSender, resultSenders);
        }
        [Test]
        public void GetAllSendersWithTransactionStatusThrowExceptionWhenDoesNotExistTransactionsWithSuchStatus()
        {
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldWorkCorrectly()
        {
            //Arrange
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);

            chainblock.Add(thirdTransaction);
            ITransaction transactionWithDifferentReceivers = new Transaction
            {
                Id = 1111,
                From = "Nencho",
                To = "Mario",
                Amount = 10500,
                Status = TransactionStatus.Successfull
            };
            chainblock.Add(transactionWithDifferentReceivers);

            //Act
            IEnumerable<string> expectedReceivers = new List<string> { "Joro", "Joro", "Mario" };
            IEnumerable<string> resultReceivers = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            //Assert
            CollectionAssert.AreEqual(expectedReceivers, resultReceivers);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusThrowExceptionWhenDoesNotExistTransactionsWithSuchStatus()
        {
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldWorkCorrectly()
        {
            //Arrange
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            //Act
            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction>() { transaction, secondTransaction };
            IEnumerable<ITransaction> result = chainblock.GetAllOrderedByAmountDescendingThenById();
            CollectionAssert.AreEqual(expectedTransactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id), result);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldWorCorrectly()
        {
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);

            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction>() { transaction, secondTransaction };
            IEnumerable<ITransaction> result = chainblock.GetBySenderOrderedByAmountDescending("Stoyan");

            CollectionAssert.AreEqual(expectedTransactions.OrderByDescending(x => x.Amount), result);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionWhenThereAreNoSenders()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("Stoyan"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldWorkCorrectly()
        {
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction>() { transaction, secondTransaction };
            IEnumerable<ITransaction> result = chainblock.GetByReceiverOrderedByAmountThenById("Joro");

            CollectionAssert.AreEqual(expectedTransactions.OrderBy(x => x.Amount).ThenBy(x => x.Id), result);
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowExceptionWhenThereAreNoReceivers()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("Pencho"));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldWorlCorrectly()
        {
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction>() { secondTransaction };
            IEnumerable<ITransaction> result = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 99);
            CollectionAssert.AreEqual(expectedTransactions, result);
        }
        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollectionWhenThereAreNoTransactions()
        {
            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction>();
            IEnumerable<ITransaction> result = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 99);
            CollectionAssert.AreEqual(expectedTransactions, result);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldWorkCorrectly()
        {
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction>() { thirdTransaction, transaction };
            IEnumerable<ITransaction> result = chainblock.GetBySenderAndMinimumAmountDescending("Stoyan", 50);
            CollectionAssert.AreEqual(expectedTransactions.OrderByDescending(x => x.Amount), result);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowExceptionWhenThereAreNoTransactions()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("Stoyan", 50));
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldWorkCorrectly()
        {
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction>() { secondTransaction };
            IEnumerable<ITransaction> result = chainblock.GetByReceiverAndAmountRange("Joro", 50, 99);
            CollectionAssert.AreEqual(expectedTransactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id), result);

        }
        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowExceptionIfThereAreNoSuchTransactions()
        {

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Joro", 50, 99));

        }

        [Test]
        public void GetAllInAmountRangeShouldWorkCorrectly()
        {
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction>() { transaction, secondTransaction };
            IEnumerable<ITransaction> result = chainblock.GetAllInAmountRange(50, 122);
            CollectionAssert.AreEqual(expectedTransactions, result);
        }
        [Test]
        public void GetAllInAmountRangeShouldReturnEmptyCollectionIfNoSuchTransactionsWereFound()
        {

            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction>();
            IEnumerable<ITransaction> result = chainblock.GetAllInAmountRange(50, 122);
            CollectionAssert.AreEqual(expectedTransactions, result);
        }
        [Test]
        public void GetEnumeratorShouldWorkCorrectly()
        {
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            IEnumerable<ITransaction> expectedTransactions = new List<ITransaction>()
            { transaction,secondTransaction,thirdTransaction};
            IEnumerable<ITransaction> result = chainblock.ToList();
            CollectionAssert.AreEqual(expectedTransactions, result);
        }
    }
}
