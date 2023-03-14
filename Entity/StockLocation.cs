using System.Drawing;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class StockLocation : AbstractEntity
    {
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("city")]
        public string? City { get; }
        [JsonPropertyName("street")]
        public string? Street { get; }
        [JsonPropertyName("house_number")]
        public string? House_Number { get; }
        [JsonPropertyName("postal_code")]
        public string? Postal_Code { get; }
        [JsonPropertyName("state_province")]
        public string? State_Province { get; }
        [JsonPropertyName("country")]
        public string? Country { get; }
        [JsonPropertyName("active")]
        public bool Active { get; }
        [JsonPropertyName("type")]
        public EStockLocationType Type { get; }
        [JsonPropertyName("color")]
        [JsonConverter(typeof(Converter.ColorConverter))]
        public Color Color { get; }
        [JsonPropertyName("in_archive")]
        public bool In_Archive { get; }

        [JsonConstructor]
        public StockLocation(
            uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName, string? updateHash,
            string? name, string? city, string? street, string? house_Number, string? postal_Code,
            string? state_Province, string? country, bool active, EStockLocationType type, Color color, bool in_Archive)
            : base(id, created, modified, creator, displayName, updateHash)
        {
            Name = name;
            City = city;
            Street = street;
            House_Number = house_Number;
            Postal_Code = postal_Code;
            State_Province = state_Province;
            Country = country;
            Active = active;
            Type = type;
            Color = color;
            In_Archive = in_Archive;
        }

        public override string ToString()
        {
            return $"StockLocation\t{ID}\t{DisplayName}";
        }

        [JsonConverter(typeof(EStockLocationTypeConverter))]
        public enum EStockLocationType
        {
            Plannable,
            NonPlannable
        }
    }
}