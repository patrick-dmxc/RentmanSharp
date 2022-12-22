using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class Rate : AbstractEntity
    {
        public string? Name { get; set; }
        public bool Archived { get; set; }
        public ERateType Type { get; set; }
        public ERateSubType Subtype { get; set; }

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