using System;
using System.Collections.Generic;

namespace TransactionLedger.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Purchase = new HashSet<Purchase>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }

        public ICollection<Purchase> Purchase { get; set; }
    }
}
