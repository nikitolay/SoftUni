using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Contracts
{
    public interface ITransaction : IComparable<ITransaction>
    {
        int Id { get; set; }

        TransactionStatus Status { get; set; }

        string From { get; set; }

        string To { get; set; }

        double Amount { get; set; }
    }
}
