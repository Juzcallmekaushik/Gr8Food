using System;

namespace Gr8Food
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int OrderId { get; set; }
        public int CustomerUserId { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public string Message { get; set; }
        public string Reply { get; set; }
        public DateTime FeedbackDate { get; set; }
        public DateTime? ReplyDate { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0} | {1} | {2} | Reply: {3}",
                CustomerName,
                ItemName,
                Message,
                string.IsNullOrWhiteSpace(Reply) ? "Pending" : Reply);
        }
    }
}
