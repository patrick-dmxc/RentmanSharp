namespace RentmanSharp.Entity
{
    public class Repair : AbstractEntity
    {
        [JsonPropertyName("equipment")]
        public string Equipment { get; }
        [JsonPropertyName("serialnumber")]
        public string SerialNumber { get; }
        [JsonPropertyName("reporter")]
        public string Reporter { get; }
        [JsonPropertyName("assignee")]
        public string? Assignee { get; }
        [JsonPropertyName("external_repairer")]
        public string? External_Repairer { get; }
        [JsonPropertyName("number")]
        public int Number { get; }
        [JsonPropertyName("repairperiod_start")]
        public DateTime RepairPeriod_Start { get; }
        [JsonPropertyName("repairperiod_end")]
        public DateTime? RepairPeriod_End { get; }
        [JsonPropertyName("amount")]
        public int Amount { get; }
        [JsonPropertyName("remark")]
        public string Remark { get; }
        [JsonPropertyName("repair_costs")]
        public double Repair_Costs { get; }
        [JsonPropertyName("is_usable")]
        public byte Is_Usable { get; }
        [JsonPropertyName("costs_charged_to_customer")]
        public string? Costs_Charged_To_Customer { get; }
        [JsonPropertyName("subproject")]
        public string? SubProject { get; }
        [JsonPropertyName("stock_location")]
        public string Stock_Location { get; }
        [JsonPropertyName("tags")]
        public string Tags { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public Repair(uint id, DateTime created, DateTime modified, string creator, string displayName,
                      string updateHash, string equipment, string serialNumber, string reporter, string? assignee,
                      string external_Repairer, int number, DateTime repairPeriod_Start, DateTime? repairPeriod_End,
                      int amount, string remark, double repair_Costs, byte is_Usable,
                      string? costs_Charged_To_Customer, string? subProject, string stock_Location, string tags,
                      JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Equipment = equipment;
            SerialNumber = serialNumber;
            Reporter = reporter;
            Assignee = assignee;
            External_Repairer = external_Repairer;
            Number = number;
            RepairPeriod_Start = repairPeriod_Start;
            RepairPeriod_End = repairPeriod_End;
            Amount = amount;
            Remark = remark;
            Repair_Costs = repair_Costs;
            Is_Usable = is_Usable;
            Costs_Charged_To_Customer = costs_Charged_To_Customer;
            SubProject = subProject;
            Stock_Location = stock_Location;
            Tags = tags;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"Repair\t{ID}\t{DisplayName}\t{Repair_Costs}EUR\t{Remark?.Replace("\r", "").Replace("\n", "")}";
        }
    }
}