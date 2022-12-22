using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.Appointment;

namespace RentmanSharp.Entity
{
    public class ERecurrenceIntervalUnitConverter : JsonConverter<ERecurrenceIntervalUnit>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ERecurrenceIntervalUnit);
        }

        public override ERecurrenceIntervalUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "once":
                    return ERecurrenceIntervalUnit.Once;
                case "days":
                    return ERecurrenceIntervalUnit.Days;
                case "weeks":
                    return ERecurrenceIntervalUnit.Weeks;
                case "months":
                    return ERecurrenceIntervalUnit.Months;
                case "years":
                    return ERecurrenceIntervalUnit.Years;
            }
            return (ERecurrenceIntervalUnit)Enum.Parse(typeof(ERecurrenceIntervalUnit), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, ERecurrenceIntervalUnit value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case ERecurrenceIntervalUnit.Once:
                    writer.WriteStringValue("once");
                    break;
                case ERecurrenceIntervalUnit.Days:
                    writer.WriteStringValue("days");
                    break;
                case ERecurrenceIntervalUnit.Weeks:
                    writer.WriteStringValue("weeks");
                    break;
                case ERecurrenceIntervalUnit.Months:
                    writer.WriteStringValue("months");
                    break;
                case ERecurrenceIntervalUnit.Years:
                    writer.WriteStringValue("years");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}