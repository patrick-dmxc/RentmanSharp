using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class Accessorie : AbstractEntity
    {
        [JsonPropertyName("parent_equipment")]
        public string? Parent_Equipment { get; }
        [JsonPropertyName("equipment")]
        public string? Equipment { get; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; }
        [JsonPropertyName("automatic")]
        public bool Automatic { get; }

        [JsonConstructor]
        public Accessorie(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                          string? updateHash, string? parent_Equipment, string? equipment, int quantity, bool automatic) : base(id, created, modified, creator, displayName, updateHash)
        {
            Parent_Equipment = parent_Equipment;
            Equipment = equipment;
            Quantity = quantity;
            Automatic = automatic;
        }

        public override string ToString()
        {
            return $"Accessorie\t{ID}\t{DisplayName}";
        }
    }
}
