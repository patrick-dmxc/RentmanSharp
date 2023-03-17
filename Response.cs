namespace RentmanSharp
{
    public class Response
    {
        public JsonElement Data { get; set; }
        public int ItemCount { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
