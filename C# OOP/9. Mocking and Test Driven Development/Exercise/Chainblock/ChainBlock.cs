using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class ChainBlock : IChainBlock
    {

        private readonly Dictionary<int, ITransaction> transactions;

        public ChainBlock()
        {
            this.transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!Contains(tx))
            {
                transactions.Add(tx.Id, tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (Contains(id))
            {
                transactions[id].Status = newStatus;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool Contains(ITransaction tx)
            => transactions.ContainsKey(tx.Id);

        public bool Contains(int id)
            => transactions.ContainsKey(id);


        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        => transactions.Values.Where(x => x.Amount >= lo && x.Amount <= hi);

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
                     => transactions.Values.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> receivers = new List<string>();
            receivers = transactions.Values.Where(x => x.Status == status).Select(x => x.To).ToList();
            if (receivers.Any())
            {
                return receivers;

            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> senders = new List<string>();
            senders = transactions.Values.Where(x => x.Status == status).Select(x => x.From).ToList();
            if (senders.Any())
            {
                return senders;

            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public ITransaction GetById(int id)
        {
            if (Contains(id))
            {
                return transactions[id];
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            List<ITransaction> transactions = new List<ITransaction>();
            transactions = this.transactions.Values.Where(x => x.To == receiver && x.Amount >= lo && x.Amount <= hi).OrderBy(x => x.Amount).ThenBy(x => x.Id).ToList();
            if (transactions.Any())
            {
                return transactions;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            List<ITransaction> transactions = new List<ITransaction>();
            transactions = this.transactions.Values.Where(x => x.To == receiver).OrderBy(x => x.Amount).ThenBy(x => x.Id).ToList();
            if (transactions.Any())
            {
                return transactions;

            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> transactions = this.transactions.Values.Where(x => x.From == sender && x.Amount > amount).OrderByDescending(x => x.Amount);
            if (transactions.Any())
            {
                return transactions;
            }
            else
            {
                throw new InvalidOperationException();

            }
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> transactions = this.transactions.Values.Where(x => x.From == sender).OrderByDescending(x => x.Amount);
            if (transactions.Any())
            {
                return transactions;
            }
            else
            {
                throw new InvalidOperationException();

            }
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            ITransaction transaction = transactions.FirstOrDefault(x => x.Value.Status == status).Value;
            if (transaction == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return transactions.Values.Where(x => x.Status == status).OrderByDescending(x => x.Amount);
            }
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        => transactions.Values.Where(x => x.Amount <= amount && x.Status == status);

        public void RemoveTransactionById(int id)
        {
            if (Contains(id))
            {
                transactions.Remove(id);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in transactions.Values)
            {
                yield return transaction;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
