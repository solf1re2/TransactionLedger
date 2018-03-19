using System;
using System.Collections.Generic;

namespace TransactionLedger.Models
{
    public partial class SaleDetail
    {
        public int Id { get; set; }
        public string ItemDescription { get; set; }
        public int? ItemId { get; set; }
        public int SaleId { get; set; }
        public decimal Value { get; set; }

        public Sale Item { get; set; }
    }
}
