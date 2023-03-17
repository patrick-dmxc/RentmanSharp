namespace RentmanSharp.Entity
{
    public class EquipmentSetsContentItem : AbstractEntity
    {
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("parent_equipment")]
        public string Parent_Equipment { get; set; }
        [JsonPropertyName("order")]
        public int Order { get; set; }
        [JsonPropertyName("equipment")]
        public string Equipment { get; set; }

        [JsonConstructor]
        public EquipmentSetsContentItem(uint id, DateTime created, DateTime modified, string creator,
                                        string displayName, string updateHash, int quantity, string parent_Equipment,
                                        int order, string equipment) : base(id, created, modified, creator, displayName, updateHash)
        {
            Quantity = quantity;
            Parent_Equipment = parent_Equipment;
            Order = order;
            Equipment = equipment;
        }

        public override string ToString()
        {
            return $"EquipmentSetsContent\t{ID}\t{DisplayName}";
        }
    }
}