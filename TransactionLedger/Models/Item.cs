using System;
using System.Collections.Generic;

namespace TransactionLedger.Models
{
    public partial class Item
    {
        public Item()
        {
            TransactionDetail = new HashSet<TransactionDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<TransactionDetail> TransactionDetail { get; set; }
    }
}
