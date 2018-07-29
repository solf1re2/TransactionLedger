using System;
using System.Collections.Generic;

namespace TransactionLedger.Models
{
    public partial class TransactionDetail
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public int? ItemId { get; set; }
        public decimal Value { get; set; }

        public Item Item { get; set; }
        public Transaction Transaction { get; set; }
    }
}
