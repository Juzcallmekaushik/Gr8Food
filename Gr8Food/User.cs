namespace Gr8Food
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public decimal WalletBalance { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0} ({1})", Username, Role);
        }
    }
}
