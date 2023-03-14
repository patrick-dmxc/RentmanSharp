using System.Text.Json;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class ProjectEquipmentItem : AbstractEntity
    {
        [JsonPropertyName("equipment")]
        public string? Equipment { get; }
        [JsonPropertyName("parent")]
        public string? Parent { get; }
        [JsonPropertyName("ledger")]
        public string? Ledger { get; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; }
        [JsonPropertyName("quantity_total")]
        public int Quantity_Total { get; }
        [JsonPropertyName("equipment_group")]
        public string? Equipment_Group { get; }
        [JsonPropertyName("discount")]
        public double Discount { get; }
        [JsonPropertyName("is_option")]
        public bool Is_Option { get; }
        [JsonPropertyName("factor")]
        public double Factor { get; }
        [JsonPropertyName("order")]
        public int Order { get; }
        [JsonPropertyName("unit_price")]
        public double Unit_Price { get; }
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("external_remark")]
        public string? External_Remark { get; }
        [JsonPropertyName("internal_remark")]
        public string? Internal_Remark { get; }
        [JsonPropertyName("delay_notified")]
        public bool Delay_Notified { get; }
        [JsonPropertyName("planperiod_start")]
        public DateTime? Planperiod_Start { get; }
        [JsonPropertyName("planperiod_end")]
        public DateTime? Planperiod_End { get; }
        [JsonPropertyName("has_missings")]
        public bool Has_Missings { get; }
        [JsonPropertyName("warehouse_reservations")]
        public int Warehouse_Reservations { get; }
        [JsonPropertyName("subrent_reservations")]
        public int Subrent_Reservations { get; }
        [JsonPropertyName("serial_number_ids")]
        public string? Serial_Number_IDs { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public ProjectEquipmentItem(uint? id, DateTime? created, DateTime? modified, string? creator,
                                    string? displayName, string? updateHash, string? equipment, string? parent,
                                    string? ledger, int quantity, int quantity_Total, string? equipment_Group,
                                    double discount, bool is_Option, double factor, int order, double unit_Price,
                                    string? name, string? external_Remark, string? internal_Remark, bool delay_Notified,
                                    DateTime? planperiod_Start, DateTime? planperiod_End, bool has_Missings,
                                    int warehouse_Reservations, int subrent_Reservations, string? serial_Number_IDs,
                                    JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Equipment = equipment;
            Parent = parent;
            Ledger = ledger;
            Quantity = quantity;
            Quantity_Total = quantity_Total;
            Equipment_Group = equipment_Group;
            Discount = discount;
            Is_Option = is_Option;
            Factor = factor;
            Order = order;
            Unit_Price = unit_Price;
            Name = name;
            External_Remark = external_Remark;
            Internal_Remark = internal_Remark;
            Delay_Notified = delay_Notified;
            Planperiod_Start = planperiod_Start;
            Planperiod_End = planperiod_End;
            Has_Missings = has_Missings;
            Warehouse_Reservations = warehouse_Reservations;
            Subrent_Reservations = subrent_Reservations;
            Serial_Number_IDs = serial_Number_IDs;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"ProjectEquipment\t{ID}\t{Quantity}x\t{DisplayName} ";
        }
    }
}