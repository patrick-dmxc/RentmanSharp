using System.Drawing;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace RentmanSharp.Entity
{
    public class Appointment : AbstractEntity
    {
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("start")]
        public DateTime Start { get; }
        [JsonPropertyName("end")]
        public DateTime End { get; }

        [JsonPropertyName("color")]
        [JsonConverter(typeof(Converter.ColorConverter))]
        public Color? Color { get; }
        [JsonPropertyName("is_plannable")]
        public bool? Is_Plannable { get; }
        [JsonPropertyName("recurrence_interval_unit")]
        public ERecurrenceIntervalUnit? Recurrence_Interval_Unit { get; }
        [JsonPropertyName("recurrence_enddate")]
        public string? Recurrence_Enddate { get; }
        [JsonPropertyName("recurrence_interval")]
        public int? Recurrence_Interval { get; }
        [JsonPropertyName("synchronization_id")]
        public string? Synchronization_Id { get; }
        [JsonPropertyName("synchronisation_uri")]
        public string? Synchronisation_Uri { get; }
        [JsonPropertyName("remark")]
        public string? Remark { get; }
        [JsonPropertyName("is_public")]
        public bool? Is_Public { get; }
        [JsonPropertyName("location")]
        public string? Location { get; }
        [JsonPropertyName("recurrent_group")]
        public int? Recurrent_Group { get; }

        [JsonConstructor]
        public Appointment(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                           string? updateHash, string? name, DateTime start, DateTime end, Color? color,
                           bool? is_Plannable, ERecurrenceIntervalUnit? recurrence_Interval_Unit,
                           string? recurrence_Enddate, int? recurrence_Interval, string? synchronization_Id,
                           string? synchronisation_Uri, string? remark, bool? is_Public, string? location,
                           int? recurrent_Group) : base(id, created, modified, creator, displayName, updateHash)
        {
            Name = name;
            Start = start;
            End = end;
            Color = color;
            Is_Plannable = is_Plannable;
            Recurrence_Interval_Unit = recurrence_Interval_Unit;
            Recurrence_Enddate = recurrence_Enddate;
            Recurrence_Interval = recurrence_Interval;
            Synchronization_Id = synchronization_Id;
            Synchronisation_Uri = synchronisation_Uri;
            Remark = remark;
            Is_Public = is_Public;
            Location = location;
            Recurrent_Group = recurrent_Group;
        }

        public override string ToString()
        {
            return $"Appointment\t{ID}\t{DisplayName} {Start} - {End}";
        }
        [JsonConverter(typeof(ERecurrenceIntervalUnitConverter))]
        public enum ERecurrenceIntervalUnit
        {
            Once,
            Days,
            Weeks,
            Months,
            Years
        }
    }
}
