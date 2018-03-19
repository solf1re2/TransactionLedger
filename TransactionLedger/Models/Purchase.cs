using System;
using System.Collections.Generic;

namespace TransactionLedger.Models
{
    public partial class Purchase
    {
        public Purchase()
        {
            PurchaseDetail = new HashSet<PurchaseDetail>();
        }

        public int Id { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public int SupplierId { get; set; }
        public decimal Value { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetail { get; set; }
    }
}
