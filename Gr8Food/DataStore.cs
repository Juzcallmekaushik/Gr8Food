namespace Gr8Food
{
    public static class AppSession
    {
        public static User CurrentUser { get; set; }
        public static bool IsLoggingOut { get; set; }
    }
}
