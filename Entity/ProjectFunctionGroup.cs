namespace RentmanSharp.Entity
{
    public class ProjectFunctionGroup : AbstractEntity
    {

        [JsonPropertyName("name")]
        public string Name { get; }
        [JsonPropertyName("project")]
        public string Project { get; }
        [JsonPropertyName("subproject")]
        public string SubProject { get; }
        [JsonPropertyName("duration")]
        public int Duration { get; }
        [JsonPropertyName("planperiod_start_schedule_is_start")]
        public int Planperiod_Start_Schedule_Is_Start { get; }
        [JsonPropertyName("usageperiod_start_schedule_is_start")]
        public int Usageperiod_Start_Schedule_Is_Start { get; }
        [JsonPropertyName("planperiod_end_schedule_is_start")]
        public int Planperiod_End_Schedule_Is_Start { get; }
        [JsonPropertyName("usageperiod_end_schedule_is_start")]
        public int Usageperiod_End_Schedule_Is_Start { get; }
        [JsonPropertyName("usageperiod_start")]
        public DateTime? Usageperiod_Start { get; }
        [JsonPropertyName("usageperiod_end")]
        public DateTime? Usageperiod_End { get; }
        [JsonPropertyName("planperiod_start")]
        public DateTime? Planperiod_Start { get; }
        [JsonPropertyName("planperiod_end")]
        public DateTime? Planperiod_End { get; }
        [JsonPropertyName("remark")]
        public string Remark { get; }

        [JsonConstructor]
        public ProjectFunctionGroup(uint id, DateTime created, DateTime modified, string creator,
                                    string displayName, string updateHash, string name, string project,
                                    string subProject, int duration, int planperiod_Start_Schedule_Is_Start,
                                    int usageperiod_Start_Schedule_Is_Start, int planperiod_End_Schedule_Is_Start,
                                    int usageperiod_End_Schedule_Is_Start, DateTime? usageperiod_Start,
                                    DateTime? usageperiod_End, DateTime? planperiod_Start, DateTime? planperiod_End,
                                    string remark) : base(id, created, modified, creator, displayName, updateHash)
        {
            Name = name;
            Project = project;
            SubProject = subProject;
            Duration = duration;
            Planperiod_Start_Schedule_Is_Start = planperiod_Start_Schedule_Is_Start;
            Usageperiod_Start_Schedule_Is_Start = usageperiod_Start_Schedule_Is_Start;
            Planperiod_End_Schedule_Is_Start = planperiod_End_Schedule_Is_Start;
            Usageperiod_End_Schedule_Is_Start = usageperiod_End_Schedule_Is_Start;
            Usageperiod_Start = usageperiod_Start;
            Usageperiod_End = usageperiod_End;
            Planperiod_Start = planperiod_Start;
            Planperiod_End = planperiod_End;
            Remark = remark;
        }

        public override string ToString()
        {
            return $"ProjectFunctionGroup\t{ID}\t{DisplayName} {Planperiod_Start} - {Planperiod_End}";
        }
    }
}