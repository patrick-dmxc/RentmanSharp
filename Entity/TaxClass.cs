using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class TaxClass : AbstractEntity
    {
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("code")]
        public string? Code { get; }
        [JsonPropertyName("type")]
        public ETaxClassType Type { get; }

        [JsonConstructor]
        public TaxClass(
            uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName, string? updateHash,
            string? name, string? code, ETaxClassType type) : base(id, created, modified, creator, displayName, updateHash)
        {
            Name = name;
            Code = code;
            Type = type;
        }

        public override string ToString()
        {
            return $"TaxClass\t{ID}\t{Code}\t{Name}";
        }
        [JsonConverter(typeof(ETaxClassTypeConverter))]
        public enum ETaxClassType
        {
            VAT,
            Tax,
            NoTax
        }
    }
}