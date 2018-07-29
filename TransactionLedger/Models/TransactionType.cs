using System;
using System.Collections.Generic;

namespace TransactionLedger.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Transaction> Transaction { get; set; }
    }
}
