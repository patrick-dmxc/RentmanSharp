namespace RentmanSharp.Entity
{
    public class TimeRegistrationItem : AbstractEntity
    {
        [JsonPropertyName("crewmember")]
        public string Crewmember { get; }
        [JsonPropertyName("start")]
        public DateTime Start { get; }
        [JsonPropertyName("end")]
        public DateTime End { get; }
        [JsonPropertyName("distance")]
        public double Distance { get; }
        [JsonPropertyName("is_lunch_included")]
        public bool Is_Lunch_Included { get; }
        [JsonPropertyName("type")]
        public ETimeRegistrationItemType Type { get; }
        [JsonPropertyName("break_duration")]
        public double Break_Duration { get; }
        [JsonPropertyName("travel_time")]
        public double Travel_Time { get; }
        [JsonPropertyName("correction_duration")]
        public double Correction_Duration { get; }
        [JsonPropertyName("registered_by_clocking")]
        public bool Registered_By_Clocking { get; }
        [JsonPropertyName("remark")]
        public string Remark { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public TimeRegistrationItem(uint id, DateTime created, DateTime modified, string creator, string displayName, string updateHash, string crewmember, DateTime start, DateTime end, double distance, bool is_Lunch_Included, ETimeRegistrationItemType type, double break_Duration, double travel_Time, double correction_Duration, bool registered_By_Clocking, string remark, JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Crewmember = crewmember;
            Start = start;
            End = end;
            Distance = distance;
            Is_Lunch_Included = is_Lunch_Included;
            Type = type;
            Break_Duration = break_Duration;
            Travel_Time = travel_Time;
            Correction_Duration = correction_Duration;
            Registered_By_Clocking = registered_By_Clocking;
            Remark = remark;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"TimeRegistration\t{ID}\t{Type}\t{Start} - {End} Break: {Break_Duration}";
        }
        [JsonConverter(typeof(ETimeRegistrationItemTypeConverter))]
        public enum ETimeRegistrationItemType
        {
            Worked,
            Holiday,
            Correction,
            SickLeave,
            Compensation
        }
    }
}