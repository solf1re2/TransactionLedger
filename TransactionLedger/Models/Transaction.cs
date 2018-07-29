using System;
using System.Collections.Generic;

namespace TransactionLedger.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionDetail = new HashSet<TransactionDetail>();
        }

        public int Id { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public int TypeId { get; set; }
        public decimal Value { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }

        public TransactionType Type { get; set; }
        public ICollection<TransactionDetail> TransactionDetail { get; set; }
    }
}
