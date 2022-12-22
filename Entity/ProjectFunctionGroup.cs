namespace RentmanSharp.Entity
{
    public class ProjectFunctionGroup : AbstractEntity
    {
        public string? Name { get; set; }
        public string? Project { get; set; }
        public string? SubProject { get; set; }
        public int Duration { get; set; }
        public int Planperiod_Start_Schedule_Is_Start { get; set; }
        public int Usageperiod_Start_Schedule_Is_Start { get; set; }
        public int Planperiod_End_Schedule_Is_Start { get; set; }
        public int Usageperiod_End_Schedule_Is_Start { get; set; }
        public DateTime? Usageperiod_Start { get; set; }
        public DateTime? Usageperiod_End { get; set; }
        public DateTime? Planperiod_Start { get; set; }
        public DateTime? Planperiod_End { get; set; }
        public string? Remark { get; set; }

        public override string ToString()
        {
            return $"ProjectFunctionGroup\t{ID}\t{DisplayName} {Planperiod_Start} - {Planperiod_End}";
        }
    }
}