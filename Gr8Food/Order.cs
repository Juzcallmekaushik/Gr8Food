using System;

namespace Gr8Food
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerUserId { get; set; }
        public int ChefUserId { get; set; }
        public string CustomerName { get; set; }
        public string ChefName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ItemName { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public override string ToString()
        {
            return string.Format(
                "#{0} | {1} | {2} | RM {3:0.00} | {4} | {5:dd MMM yyyy HH:mm}",
                OrderId,
                CustomerName,
                ItemName,
                Price,
                Status,
                OrderDate);
        }
    }
}
