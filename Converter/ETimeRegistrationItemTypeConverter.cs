using static RentmanSharp.Entity.TimeRegistrationItem;

namespace RentmanSharp.Entity
{
    public class ETimeRegistrationItemTypeConverter : JsonConverter<ETimeRegistrationItemType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ETimeRegistrationItemType);
        }

        public override ETimeRegistrationItemType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "worked":
                    return ETimeRegistrationItemType.Worked;
                case "holiday":
                    return ETimeRegistrationItemType.Holiday;
                case "correction":
                    return ETimeRegistrationItemType.Correction;
                case "sick_leave":
                    return ETimeRegistrationItemType.SickLeave;
                case "compensation":
                    return ETimeRegistrationItemType.Compensation;
            }
            return (ETimeRegistrationItemType)Enum.Parse(typeof(ETimeRegistrationItemType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, ETimeRegistrationItemType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case ETimeRegistrationItemType.Worked:
                    writer.WriteStringValue("worked");
                    break;
                case ETimeRegistrationItemType.Holiday:
                    writer.WriteStringValue("holiday");
                    break;
                case ETimeRegistrationItemType.Correction:
                    writer.WriteStringValue("correction");
                    break;
                case ETimeRegistrationItemType.SickLeave:
                    writer.WriteStringValue("sick_leave");
                    break;
                case ETimeRegistrationItemType.Compensation:
                    writer.WriteStringValue("compensation");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}