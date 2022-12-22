using System.Text.Json;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class TimeRegistrationItem : AbstractEntity
    {
        public string? Crewmember { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public double Distance { get; set; }
        public bool Is_Lunch_Included { get; set; }
        public ETimeRegistrationItemType Type { get; set; }
        public double? Break_Duration { get; set; }
        public double? Travel_Time { get; set; }
        public double? Correction_Duration { get; set; }
        public bool? Registered_By_Clocking { get; set; }
        public string? Remark { get; set; }
        public JsonElement Custom { get; set; }

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