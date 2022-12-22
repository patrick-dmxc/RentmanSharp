namespace RentmanSharp
{
    internal static class Constants
    {
        public const string API_URL = "https://api.rentman.net";
        public static string? VERSION = System.Reflection.Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString();
    }
}
