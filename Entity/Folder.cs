using System.Text.Json;

namespace RentmanSharp.Entity
{
    public class Folder : AbstractEntity
    {
        public string? Parent { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }
        public string? ItemType { get; set; }
        public string? Path { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"Folder\t{ID}\t{DisplayName} {Path}";
        }
    }
}