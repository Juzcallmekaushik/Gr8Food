namespace Gr8Food
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int ChefUserId { get; set; }
        public string ChefName { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0} | {1} | RM {2:0.00} | Chef: {3} | {4}",
                Name,
                Category,
                Price,
                ChefName,
                IsAvailable ? "Available" : "Unavailable");
        }
    }
}
