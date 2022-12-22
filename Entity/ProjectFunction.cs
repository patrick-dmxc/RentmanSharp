namespace RentmanSharp.Entity
{
    public class ProjectFunction : AbstractEntity
    {
        public string? Cost_Rate { get; set; }
        public string? Price_Rate { get; set; }
        public string? Project { get; set; }
        public string? SubProject { get; set; }
        public bool Is_Template { get; set; }
        public string? Group { get; set; }
        public string? Name_External { get; set; }
        public string? Name { get; set; }
        public int Travel_Time_Before { get; set; }
        public int Travel_Time_After { get; set; }
        public DateTime? Usageperiod_Start { get; set; }
        public DateTime? Usageperiod_End { get; set; }
        public DateTime? Planperiod_Start { get; set; }
        public DateTime? Planperiod_End { get; set; }
        public string? Planperiod_Start_Schedule_Is_Start { get; set; }
        public string? Usageperiod_Start_Schedule_Is_Start { get; set; }
        public string? Planperiod_End_Schedule_Is_Start { get; set; }
        public string? Usageperiod_End_Schedule_Is_Start { get; set; }
        public string? Type { get; set; }
        public int Duration { get; set; }
        public int Amount { get; set; }
        public int Break { get; set; }
        public int Distance { get; set; }
        public bool Twoway { get; set; }
        public string? TaxClass { get; set; }
        public string? Ledger { get; set; }
        public int Order { get; set; }
        public string? Remark_Client { get; set; }
        public string? Remark_Planner { get; set; }
        public string? Remark_Crew { get; set; }
        public bool In_Financial { get; set; }
        public bool In_Planning { get; set; }
        public double Price_Fixed { get; set; }
        public double Price_Variable { get; set; }
        public double Costs_Fixed { get; set; }
        public double Costs_Variable { get; set; }

        public override string ToString()
        {
            return $"ProjectFunction\t{ID}\t{DisplayName} {Price_Fixed}EUR {Planperiod_Start} - {Planperiod_End}";
        }
    }
}