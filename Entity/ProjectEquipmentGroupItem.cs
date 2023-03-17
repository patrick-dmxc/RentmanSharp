namespace RentmanSharp.Entity
{
    public class ProjectEquipmentGroupItem : AbstractEntity
    {
        [JsonPropertyName("project")]
        public string? Project { get; }
        [JsonPropertyName("subproject")]
        public string? SubProject { get; }
        [JsonPropertyName("additional_scanned")]
        public bool Additional_Scanned { get; }
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("usageperiod_start")]
        public DateTime? Usageperiod_Start { get; }
        [JsonPropertyName("usageperiod_end")]
        public DateTime? Usageperiod_End { get; }
        [JsonPropertyName("duration")]
        public int Duration { get; }
        [JsonPropertyName("planperiod_start")]
        public DateTime? Planperiod_Start { get; }
        [JsonPropertyName("planperiod_end")]
        public DateTime? Planperiod_End { get; }
        [JsonPropertyName("is_delayed")]
        public bool Is_Delayed { get; }
        [JsonPropertyName("order")]
        public int Order { get; }
        [JsonPropertyName("in_price_calculation")]
        public bool In_Price_Calculation { get; }
        [JsonPropertyName("remark")]
        public string? Remark { get; }
        [JsonPropertyName("volume")]
        public double Volume { get; }
        [JsonPropertyName("weight")]
        public double Weight { get; }
        [JsonPropertyName("power")]
        public double Power { get; }
        [JsonPropertyName("current")]
        public double Current { get; }
        [JsonPropertyName("total_new_price")]
        public double Total_New_Price { get; }

        [JsonConstructor]
        public ProjectEquipmentGroupItem(uint? id, DateTime? created, DateTime? modified, string? creator,
                                         string? displayName, string? updateHash, string? project, string? subProject,
                                         bool additional_Scanned, string? name, DateTime? usageperiod_Start,
                                         DateTime? usageperiod_End, int duration, DateTime? planperiod_Start,
                                         DateTime? planperiod_End, bool is_Delayed, int order, bool in_Price_Calculation,
                                         string? remark, double volume, double weight, double power, double current,
                                         double total_New_Price) : base(id, created, modified, creator, displayName, updateHash)
        {
            Project = project;
            SubProject = subProject;
            Additional_Scanned = additional_Scanned;
            Name = name;
            Usageperiod_Start = usageperiod_Start;
            Usageperiod_End = usageperiod_End;
            Duration = duration;
            Planperiod_Start = planperiod_Start;
            Planperiod_End = planperiod_End;
            Is_Delayed = is_Delayed;
            Order = order;
            In_Price_Calculation = in_Price_Calculation;
            Remark = remark;
            Volume = volume;
            Weight = weight;
            Power = power;
            Current = current;
            Total_New_Price = total_New_Price;
        }

        public override string ToString()
        {
            return $"ProjectEquipmentGroup\t{ID}\t{DisplayName} {Total_New_Price}EUR";
        }
    }
}