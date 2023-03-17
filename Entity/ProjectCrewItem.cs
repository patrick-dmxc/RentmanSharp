namespace RentmanSharp.Entity
{
    public class ProjectCrewItem : AbstractEntity
    {
        [JsonPropertyName("cost_rate")]
        public string? Cost_Rate { get; }
        [JsonPropertyName("function")]
        public string? Function { get; }
        [JsonPropertyName("crewmember")]
        public string? CrewMember { get; }
        [JsonPropertyName("visible")]
        public bool Visible { get; }
        [JsonPropertyName("planperiod_start")]
        public DateTime? Planperiod_Start { get; }
        [JsonPropertyName("planperiod_end")]
        public DateTime? Planperiod_End { get; }
        [JsonPropertyName("transport")]
        public string? Transport { get; }
        [JsonPropertyName("remark")]
        public string? Remark { get; }
        [JsonPropertyName("remark_planner")]
        public string? Remark_Planner { get; }
        [JsonPropertyName("invoice_reference")]
        public string? Invoice_Reference { get; }
        [JsonPropertyName("project_leader")]
        public bool Project_Leader { get; }
        [JsonPropertyName("is_visible_on_dashboard")]
        public bool Is_Visible_On_Dashboard { get; }
        [JsonPropertyName("costs")]
        public double Costs { get; }
        [JsonPropertyName("cost_actual")]
        public double Cost_Actual { get; }
        [JsonPropertyName("hours_registered")]
        public int Hours_Registered { get; }
        [JsonPropertyName("hours_planned")]
        public int Hours_Planned { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public ProjectCrewItem(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                               string? updateHash, string? cost_Rate, string? function, string? crewMember, bool visible,
                               DateTime? planperiod_Start, DateTime? planperiod_End, string? transport, string? remark,
                               string? remark_Planner, string? invoice_Reference, bool project_Leader,
                               bool is_Visible_On_Dashboard, double costs, double cost_Actual, int hours_Registered,
                               int hours_Planned, JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Cost_Rate = cost_Rate;
            Function = function;
            CrewMember = crewMember;
            Visible = visible;
            Planperiod_Start = planperiod_Start;
            Planperiod_End = planperiod_End;
            Transport = transport;
            Remark = remark;
            Remark_Planner = remark_Planner;
            Invoice_Reference = invoice_Reference;
            Project_Leader = project_Leader;
            Is_Visible_On_Dashboard = is_Visible_On_Dashboard;
            Costs = costs;
            Cost_Actual = cost_Actual;
            Hours_Registered = hours_Registered;
            Hours_Planned = hours_Planned;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"ProjectCrew\t{ID}\t{DisplayName} {Planperiod_Start} - {Planperiod_End}";
        }
    }
}