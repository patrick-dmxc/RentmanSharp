using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class CrewAvilabilityItem : AbstractEntity
    {
        public string? Last_Updater { get; set; }
        public string? Last_Updated { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? CrewMember { get; set; }
        public ECrewAvilabilityStatus? Status { get; set; }
        public string? Remark { get; set; }

        public override string ToString()
        {
            return $"CrewAvilability\t{ID}\t{DisplayName} {Status}";
        }
        [JsonConverter(typeof(ECrewAvilabilityStatusConverter))]
        public enum ECrewAvilabilityStatus
        {
            Available,
            Unavailable,
            Unknown
        }
    }
}
