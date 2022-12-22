using System.Drawing;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class StockLocation : AbstractEntity
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? House_Number { get; set; }
        public string? Postal_Code { get; set; }
        public string? State_Province { get; set; }
        public string? Country { get; set; }
        public bool Active { get; set; }
        public EStockLocationType Type { get; set; }
        [JsonConverter(typeof(Converter.ColorConverter))]
        public Color Color { get; set; }
        public bool In_Archive { get; set; }

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