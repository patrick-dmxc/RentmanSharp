namespace RentmanSharp.Entity
{
    public class ProjectVehicle : AbstractEntity
    {
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("cost_rate")]
        public string? Cost_Rate { get; }
        [JsonPropertyName("function")]
        public string? Function { get; }
        [JsonPropertyName("transport")]
        public string? Transport { get; }
        [JsonPropertyName("vehicle")]
        public string? Vehicle { get; }
        [JsonPropertyName("planningperiod_start")]
        public DateTime? Planningperiod_Start { get; }
        [JsonPropertyName("planningperiod_end")]
        public DateTime? Planningperiod_End { get; }
        [JsonPropertyName("remark")]
        public string? Remark { get; }
        [JsonPropertyName("remark_planner")]
        public string? Remark_Planner { get; }
        [JsonPropertyName("costs")]
        public double Costs { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public ProjectVehicle(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
            string? updateHash, string? name, string? cost_Rate, string? function, string? transport, string? vehicle,
            DateTime? planningperiod_Start, DateTime? planningperiod_End, string? remark, string? remark_Planner,
            double costs, JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Name = name;
            Cost_Rate = cost_Rate;
            Function = function;
            Transport = transport;
            Vehicle = vehicle;
            Planningperiod_Start = planningperiod_Start;
            Planningperiod_End = planningperiod_End;
            Remark = remark;
            Remark_Planner = remark_Planner;
            Costs = costs;
            Custom = custom;
        }
        
        public override string ToString()
        {
            return $"ProjectVehicle\t{ID}\t{DisplayName} ";
        }
        [JsonConverter(typeof(ETransportConverter))]
        public enum ETransport
        {
            NoTransport,
            RoundTrip,
            OnlyWayThere,
            OnlyWayBack
        }
    }
}