using System.Drawing;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class ProjectType : AbstractEntity
    {
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("color")]
        [JsonConverter(typeof(Converter.ColorConverter))]
        public Color Color { get; }
        [JsonPropertyName("type")]
        public string? Type { get; }

        [JsonConstructor]
        public ProjectType(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                           string? updateHash, string? name, Color color, string? type) : base(id, created, modified, creator, displayName, updateHash)
        {
            Name = name;
            Color = color;
            Type = type;
        }

        public override string ToString()
        {
            return $"ProjectType\t{ID}\t{DisplayName} ";
        }
    }
}