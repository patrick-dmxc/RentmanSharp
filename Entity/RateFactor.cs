namespace RentmanSharp.Entity
{
    public class RateFactor : AbstractEntity
    {
        [JsonPropertyName("rate_id")]
        public string Rate_ID { get; }
        [JsonPropertyName("name")]
        public string Name { get; }
        [JsonPropertyName("from")]
        public double From { get; }
        [JsonPropertyName("to")]
        public double To { get; }
        [JsonPropertyName("variable")]
        public double Variable { get; }
        [JsonPropertyName("fixed")]
        public double @Fixed { get; }

        [JsonConstructor]
        public RateFactor(uint id, DateTime created, DateTime modified, string creator, string displayName,
                          string updateHash, string rate_ID, string name, double from, double to, double variable,
                          double @fixed) : base(id, created, modified, creator, displayName, updateHash)
        {
            Rate_ID = rate_ID;
            Name = name;
            From = from;
            To = to;
            Variable = variable;
            @Fixed = @fixed;
        }

        public override string ToString()
        {
            return $"RateFactor\t{ID}\t{DisplayName} V:{Variable}\tF:{Fixed}\t{From}\t-\t{To}";
        }
    }
}