using RentmanSharp.Converter;
using System.Drawing;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class Appointment : IEntity
    {
        public int ID { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        [JsonConverter(typeof(Converter.ColorConverter))]
        public Color Color { get; set; }
        public string? DisplayName { get; set; }
        public bool Is_Plannable { get; set; }
        public string? Remark { get; set; }
        public bool Is_Public { get; set; }
        public string? Location { get; set; }

        public override string ToString()
        {
            return $"Appointment\t{ID}\t{DisplayName} {Start} - {End}";
        }
    }
}
