using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class SubrentalEquipmentItem : AbstractEntity
    {
        [JsonPropertyName("subrental_group")]
        public string? Subrental_Group { get; }
        [JsonPropertyName("equipment")]
        public string? Equipment { get; }
        [JsonPropertyName("parent")]
        public string? Parent { get; }
        [JsonPropertyName("planperiod_start")]
        public DateTime? Planperiod_Start { get; }
        [JsonPropertyName("planperiod_end")]
        public DateTime? Planperiod_End { get; }
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; }
        [JsonPropertyName("quantity_total")]
        public int Quantity_Total { get; }
        [JsonPropertyName("unit_price")]
        public double Unit_Price { get; }
        [JsonPropertyName("discount")]
        public double Discount { get; }
        [JsonPropertyName("factor")]
        public double Factor { get; }
        [JsonPropertyName("order")]
        public int Order { get; }
        [JsonPropertyName("remark")]
        public string? Remark { get; }
        [JsonPropertyName("lineprice")]
        public double LinePrice { get; }
        [JsonPropertyName("supplier_planningmateriaal")]
        public string? Supplier_PlanningMaterial { get; }

        [JsonConstructor]
        public SubrentalEquipmentItem(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName, string? updateHash, string? subrental_Group, string? equipment, string? parent, DateTime? planperiod_Start, DateTime? planperiod_End, string? name, int quantity, int quantity_Total, double unit_Price, double discount, double factor, int order, string? remark, double linePrice, string? supplier_PlanningMaterial) : base(id, created, modified, creator, displayName, updateHash)
        {
            Subrental_Group = subrental_Group;
            Equipment = equipment;
            Parent = parent;
            Planperiod_Start = planperiod_Start;
            Planperiod_End = planperiod_End;
            Name = name;
            Quantity = quantity;
            Quantity_Total = quantity_Total;
            Unit_Price = unit_Price;
            Discount = discount;
            Factor = factor;
            Order = order;
            Remark = remark;
            LinePrice = linePrice;
            Supplier_PlanningMaterial = supplier_PlanningMaterial;
        }

        public override string ToString()
        {
            return $"SubrentalEquipment\t{ID}\t{Quantity}x\t{DisplayName}\t{LinePrice}";
        }
    }
}