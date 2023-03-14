using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class Rate : AbstractEntity
    {
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("archived")]
        public bool Archived { get; }
        [JsonPropertyName("type")]
        public ERateType Type { get; }
        [JsonPropertyName("subtype")]
        public ERateSubType Subtype { get; }

        [JsonConstructor]
        public Rate(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                    string? updateHash, string? name, bool archived, ERateType type, ERateSubType subtype) 
                    : base(id, created, modified, creator, displayName, updateHash)
        {
            Name = name;
            Archived = archived;
            Type = type;
            Subtype = subtype;
        }

        public override string ToString()
        {
            return $"Rate\t{ID}\t{DisplayName}\t{Type}\t{Subtype}";
        }

        [JsonConverter(typeof(ERateTypeConverter))]
        public enum ERateType
        {
            Price,
            Cost
        }

        [JsonConverter(typeof(ERateSubTypeConverter))]
        public enum ERateSubType
        {
            Global,
            Flat,
            Temp,
            OnlyWayBack
        }
    }
}