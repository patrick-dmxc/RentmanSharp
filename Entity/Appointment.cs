using RentmanSharp.Converter;
using System.Drawing;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class Appointment : AbstractEntity
    {
        public string? Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [JsonConverter(typeof(Converter.ColorConverter))]
        public Color? Color { get; set; }
        public bool? Is_Plannable { get; set; }
        public ERecurrenceIntervalUnit? Recurrence_Interval_Unit { get; set; }
        public string? Recurrence_Enddate { get; set; }
        public int? Recurrence_Interval { get; set; }
        public string? Synchronization_Id { get; set; }
        public string? Synchronisation_Uri { get; set; }
        public string? Remark { get; set; }
        public bool? Is_Public { get; set; }
        public string? Location { get; set; }
        public int? Recurrent_Group { get; set; }

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
