using System;

namespace Gr8Food
{
    public class WalletTransaction
    {
        public int TransactionId { get; set; }
        public int CustomerUserId { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime TransactionDate { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0} | RM {1:0.00} | {2} | {3:dd MMM yyyy HH:mm}",
                CustomerName,
                Amount,
                Type,
                TransactionDate);
        }
    }
}
