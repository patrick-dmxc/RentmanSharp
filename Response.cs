namespace RentmanSharp
{
    public readonly struct Response
    {
        [JsonPropertyName("Data")]
        public JsonElement Data { get; }
        [JsonPropertyName("ItemCount")]
        public int ItemCount { get; }
        [JsonPropertyName("Limit")]
        public int Limit { get; }
        [JsonPropertyName("Offset")]
        public int Offset { get; }

        [JsonConstructor]
        public Response(JsonElement data, int itemCount, int limit, int offset)
        {
            Data = data;
            ItemCount = itemCount;
            Limit = limit;
            Offset = offset;
        }
    }
}
