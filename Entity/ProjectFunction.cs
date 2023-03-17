namespace RentmanSharp.Entity
{
    public class ProjectFunction : AbstractEntity
    {
        [JsonPropertyName("cost_rate")]
        public string? Cost_Rate { get; }
        [JsonPropertyName("price_rate")]
        public string? Price_Rate { get; }
        [JsonPropertyName("project")]
        public string? Project { get; }
        [JsonPropertyName("subproject")]
        public string? SubProject { get; }
        [JsonPropertyName("is_template")]
        public bool Is_Template { get; }
        [JsonPropertyName("group")]
        public string? Group { get; }
        [JsonPropertyName("name_external")]
        public string? Name_External { get; }
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("travel_time_before")]
        public int Travel_Time_Before { get; }
        [JsonPropertyName("travel_time_after")]
        public int Travel_Time_After { get; }
        [JsonPropertyName("usageperiod_start")]
        public DateTime? Usageperiod_Start { get; }
        [JsonPropertyName("usageperiod_end")]
        public DateTime? Usageperiod_End { get; }
        [JsonPropertyName("planperiod_start")]
        public DateTime? Planperiod_Start { get; }
        [JsonPropertyName("planperiod_end")]
        public DateTime? Planperiod_End { get; }
        [JsonPropertyName("planperiod_start_schedule_is_start")]
        public string? Planperiod_Start_Schedule_Is_Start { get; }
        [JsonPropertyName("usageperiod_start_schedule_is_start")]
        public string? Usageperiod_Start_Schedule_Is_Start { get; }
        [JsonPropertyName("planperiod_end_schedule_is_start")]
        public string? Planperiod_End_Schedule_Is_Start { get; }
        [JsonPropertyName("usageperiod_end_schedule_is_start")]
        public string? Usageperiod_End_Schedule_Is_Start { get; }
        [JsonPropertyName("type")]
        public string? Type { get; }
        [JsonPropertyName("duration")]
        public int Duration { get; }
        [JsonPropertyName("amount")]
        public int Amount { get; }
        [JsonPropertyName("break")]
        public int Break { get; }
        [JsonPropertyName("distance")]
        public int Distance { get; }
        [JsonPropertyName("twoway")]
        public bool Twoway { get; }
        [JsonPropertyName("taxclass")]
        public string? TaxClass { get; }
        [JsonPropertyName("ledger")]
        public string? Ledger { get; }
        [JsonPropertyName("order")]
        public int Order { get; }
        [JsonPropertyName("remark_client")]
        public string? Remark_Client { get; }
        [JsonPropertyName("remark_planner")]
        public string? Remark_Planner { get; }
        [JsonPropertyName("remark_crew")]
        public string? Remark_Crew { get; }
        [JsonPropertyName("in_financial")]
        public bool In_Financial { get; }
        [JsonPropertyName("in_planning")]
        public bool In_Planning { get; }
        [JsonPropertyName("price_fixed")]
        public double Price_Fixed { get; }
        [JsonPropertyName("price_variable")]
        public double Price_Variable { get; }
        [JsonPropertyName("costs_fixed")]
        public double Costs_Fixed { get; }
        [JsonPropertyName("costs_variable")]
        public double Costs_Variable { get; }

        [JsonConstructor]
        public ProjectFunction(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                               string? updateHash, string? cost_Rate, string? price_Rate, string? project,
                               string? subProject, bool is_Template, string? group, string? name_External, string? name,
                               int travel_Time_Before, int travel_Time_After, DateTime? usageperiod_Start,
                               DateTime? usageperiod_End, DateTime? planperiod_Start, DateTime? planperiod_End,
                               string? planperiod_Start_Schedule_Is_Start, string? usageperiod_Start_Schedule_Is_Start,
                               string? planperiod_End_Schedule_Is_Start, string? usageperiod_End_Schedule_Is_Start,
                               string? type, int duration, int amount, int @break, int distance, bool twoway,
                               string? taxClass, string? ledger, int order, string? remark_Client,
                               string? remark_Planner, string? remark_Crew, bool in_Financial, bool in_Planning,
                               double price_Fixed, double price_Variable, double costs_Fixed, double costs_Variable) : base(id, created, modified, creator, displayName, updateHash)
        {
            Cost_Rate = cost_Rate;
            Price_Rate = price_Rate;
            Project = project;
            SubProject = subProject;
            Is_Template = is_Template;
            Group = group;
            Name_External = name_External;
            Name = name;
            Travel_Time_Before = travel_Time_Before;
            Travel_Time_After = travel_Time_After;
            Usageperiod_Start = usageperiod_Start;
            Usageperiod_End = usageperiod_End;
            Planperiod_Start = planperiod_Start;
            Planperiod_End = planperiod_End;
            Planperiod_Start_Schedule_Is_Start = planperiod_Start_Schedule_Is_Start;
            Usageperiod_Start_Schedule_Is_Start = usageperiod_Start_Schedule_Is_Start;
            Planperiod_End_Schedule_Is_Start = planperiod_End_Schedule_Is_Start;
            Usageperiod_End_Schedule_Is_Start = usageperiod_End_Schedule_Is_Start;
            Type = type;
            Duration = duration;
            Amount = amount;
            Break = @break;
            Distance = distance;
            Twoway = twoway;
            TaxClass = taxClass;
            Ledger = ledger;
            Order = order;
            Remark_Client = remark_Client;
            Remark_Planner = remark_Planner;
            Remark_Crew = remark_Crew;
            In_Financial = in_Financial;
            In_Planning = in_Planning;
            Price_Fixed = price_Fixed;
            Price_Variable = price_Variable;
            Costs_Fixed = costs_Fixed;
            Costs_Variable = costs_Variable;
        }

        public override string ToString()
        {
            return $"ProjectFunction\t{ID}\t{DisplayName} {Price_Fixed}EUR {Planperiod_Start} - {Planperiod_End}";
        }
    }
}