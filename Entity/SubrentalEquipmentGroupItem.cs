namespace RentmanSharp.Entity
{
    public class SubrentalEquipmentGroupItem : AbstractEntity
    {
        [JsonPropertyName("subrental")]
        public string Subrental { get; }
        [JsonPropertyName("name")]
        public string Name { get; }
        [JsonPropertyName("order")]
        public int Order { get; }
        [JsonPropertyName("supplier_category")]
        public string Supplier_Category { get; }

        [JsonConstructor]
        public SubrentalEquipmentGroupItem(
            uint id, DateTime created, DateTime modified, string creator, string displayName, string updateHash,
            string subrental, string name, int order, string supplier_Category) : base(id, created, modified, creator, displayName, updateHash)
        {
            Subrental = subrental;
            Name = name;
            Order = order;
            Supplier_Category = supplier_Category;
        }

        public override string ToString()
        {
            return $"SubrentalEquipmentGroup\t{ID}\t{DisplayName}";
        }
    }
}