using System.Drawing;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class ProjectType : AbstractEntity
    {
        public string? Name { get; set; }
        [JsonConverter(typeof(Converter.ColorConverter))]
        public Color Color { get; set; }
        public string? Type { get; set; }

        public override string ToString()
        {
            return $"ProjectType\t{ID}\t{DisplayName} ";
        }
    }
}