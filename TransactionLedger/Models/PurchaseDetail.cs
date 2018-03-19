using System;
using System.Collections.Generic;

namespace TransactionLedger.Models
{
    public partial class PurchaseDetail
    {
        public int Id { get; set; }
        public string ItemDescription { get; set; }
        public int? ItemId { get; set; }
        public int PurchaseId { get; set; }
        public decimal Value { get; set; }

        public Purchase Purchase { get; set; }
    }
}
