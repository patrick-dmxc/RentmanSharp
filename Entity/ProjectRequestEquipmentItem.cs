namespace RentmanSharp.Entity
{
    public class ProjectRequestEquipmentItem : AbstractEntity
    {
        [JsonPropertyName("quantity")]
        public int Quantity { get; }
        [JsonPropertyName("quantity_total")]
        public int Quantity_Total { get; }
        [JsonPropertyName("is_comment")]
        public bool Is_Comment { get; }
        [JsonPropertyName("is_kit")]
        public bool Is_Kit { get; }
        [JsonPropertyName("discount")]
        public double Discount { get; }
        [JsonPropertyName("linked_equipment")]
        public string? Linked_Equipment { get; }
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("external_remark")]
        public string? External_Remark { get; }
        [JsonPropertyName("parent")]
        public string? Parent { get; }
        [JsonPropertyName("unit_price")]
        public double Unit_Price { get; }
        [JsonPropertyName("parent_request")]
        public string? Parent_Request { get; }
        [JsonPropertyName("factor")]
        public double Factor { get; }
        [JsonPropertyName("order")]
        public int Order { get; }

        [JsonConstructor]
        public ProjectRequestEquipmentItem(uint? id, DateTime? created, DateTime? modified, string? creator,
                                           string? displayName, string? updateHash, int quantity, int quantity_Total,
                                           bool is_Comment, bool is_Kit, double discount, string? linked_Equipment,
                                           string? name, string? external_Remark, string? parent, double unit_Price,
                                           string? parent_Request, double factor, int order) : base(id, created, modified, creator, displayName, updateHash)
        {
            Quantity = quantity;
            Quantity_Total = quantity_Total;
            Is_Comment = is_Comment;
            Is_Kit = is_Kit;
            Discount = discount;
            Linked_Equipment = linked_Equipment;
            Name = name;
            External_Remark = external_Remark;
            Parent = parent;
            Unit_Price = unit_Price;
            Parent_Request = parent_Request;
            Factor = factor;
            Order = order;
        }

        public override string ToString()
        {
            return $"ProjectRequestEquipment\t{ID}\t{Quantity}x\t{DisplayName} ";
        }
    }
}