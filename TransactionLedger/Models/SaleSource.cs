using System;
using System.Collections.Generic;

namespace TransactionLedger.Models
{
    public partial class SaleSource
    {
        public SaleSource()
        {
            Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Source { get; set; }

        public ICollection<Sale> Sale { get; set; }
    }
}
