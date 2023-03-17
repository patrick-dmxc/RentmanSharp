namespace RentmanSharp.Entity
{
    public class LedgerCode : AbstractEntity
    {
        [JsonPropertyName("code")]
        public string? Code { get; }

        [JsonConstructor]
        public LedgerCode(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                          string? updateHash, string? code) : base(id, created, modified, creator, displayName, updateHash)
        {
            Code = code;
        }

        public override string ToString()
        {
            return $"LedgerCode\t{ID}\t{DisplayName}";
        }
    }
}