namespace RentmanSharp.Entity
{
    public class Status : AbstractEntity
    {
        [JsonPropertyName("name")]
        public string? Name { get; }

        [JsonConstructor]
        public Status(
            uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName, string? updateHash,
            string? name) : base(id, created, modified, creator, displayName, updateHash)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Status\t{ID}\t{DisplayName}";
        }
    }
}