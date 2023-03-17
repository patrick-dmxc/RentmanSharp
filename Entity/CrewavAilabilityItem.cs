namespace RentmanSharp.Entity
{
    public class CrewAvailabilityItem : AbstractEntity
    {
        [JsonPropertyName("last_updater")]
        public string? Last_Updater { get; }
        [JsonPropertyName("last_updated")]
        public string? Last_Updated { get; }
        [JsonPropertyName("start")]
        public DateTime? Start { get; }
        [JsonPropertyName("end")]
        public DateTime? End { get; }
        [JsonPropertyName("crewmember")]
        public string? CrewMember { get; }
        [JsonPropertyName("status")]
        public ECrewAvilabilityStatus? Status { get; }
        [JsonPropertyName("remark")]
        public string? Remark { get; }

        [JsonConstructor]
        public CrewAvailabilityItem(uint? id, DateTime? created, DateTime? modified, string? creator,
                                    string? displayName, string? updateHash, string? last_Updater, string? last_Updated,
                                    DateTime? start, DateTime? end, string? crewMember, ECrewAvilabilityStatus? status,
                                    string? remark) : base(id, created, modified, creator, displayName, updateHash)
        {
            Last_Updater = last_Updater;
            Last_Updated = last_Updated;
            Start = start;
            End = end;
            CrewMember = crewMember;
            Status = status;
            Remark = remark;
        }

        public override string ToString()
        {
            return $"CrewAvilability\t{ID}\t{DisplayName} {Status}";
        }
        [JsonConverter(typeof(ECrewAvailabilityStatusConverter))]
        public enum ECrewAvilabilityStatus
        {
            Available,
            Unavailable,
            Unknown
        }
    }
}
