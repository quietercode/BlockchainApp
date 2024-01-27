using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainApp.Code
{
    internal class Transaction
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Memo { get; set; } = string.Empty;
    }
}
