using System.Text.Json;

namespace RentmanSharp.Entity
{
    public class Repair : AbstractEntity
    {
        public string? Equipment { get; set; }
        public string? SerialNumber { get; set; }
        public string? Reporter { get; set; }
        public string? Assignee { get; set; }
        public string? External_Repairer { get; set; }
        public int Number { get; set; }
        public DateTime? RepairPeriod_Start { get; set; }
        public DateTime? RepairPeriod_End { get; set; }
        public int? amount { get; set; }
        public string? Remark { get; set; }
        public double? Repair_Costs { get; set; }
        public byte? Is_Usable { get; set; }
        public string? Costs_Charged_To_Customer { get; set; }
        public string? SubProject { get; set; }
        public string? Stock_Location { get; set; }
        public string? Tags { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"Repair\t{ID}\t{DisplayName}\t{Repair_Costs}EUR\t{Remark?.Replace("\r", "").Replace("\n", "")}";
        }
    }
}