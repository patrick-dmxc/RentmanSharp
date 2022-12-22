using System.Text.Json;

namespace RentmanSharp.Entity
{
    public class ProjectEquipmentItem : AbstractEntity
    {
        public string? Equipment { get; set; }
        public string? Parent { get; set; }
        public string? Ledger { get; set; }
        public int Quantity { get; set; }
        public int Quantity_Total { get; set; }
        public string? Equipment_Group { get; set; }
        public double Discount { get; set; }
        public bool Is_Option { get; set; }
        public double Factor { get; set; }
        public int Order { get; set; }
        public double Unit_Price { get; set; }
        public string? Name { get; set; }
        public string? External_Remark { get; set; }
        public string? Internal_Remark { get; set; }
        public bool Delay_Notified { get; set; }
        public DateTime? Planperiod_Start { get; set; }
        public DateTime? Planperiod_End { get; set; }
        public bool Has_Missings { get; set; }
        public int Warehouse_Reservations { get; set; }
        public int Subrent_Reservations { get; set; }
        public string? Serial_Number_IDs { get; set; }

        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"ProjectEquipment\t{ID}\t{Quantity}x\t{DisplayName} ";
        }
    }
}