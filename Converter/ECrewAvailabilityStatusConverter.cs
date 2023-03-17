using static RentmanSharp.Entity.CrewAvailabilityItem;

namespace RentmanSharp.Entity
{
    public class ECrewAvailabilityStatusConverter : JsonConverter<ECrewAvilabilityStatus>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ECrewAvilabilityStatus);
        }

        public override ECrewAvilabilityStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "B":
                    return ECrewAvilabilityStatus.Available;
                case "N":
                    return ECrewAvilabilityStatus.Unavailable;
                case "O":
                    return ECrewAvilabilityStatus.Unknown;
            }
            return (ECrewAvilabilityStatus)Enum.Parse(typeof(ECrewAvilabilityStatus), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, ECrewAvilabilityStatus value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case ECrewAvilabilityStatus.Available:
                    writer.WriteStringValue("B");
                    break;
                case ECrewAvilabilityStatus.Unavailable:
                    writer.WriteStringValue("N");
                    break;
                case ECrewAvilabilityStatus.Unknown:
                    writer.WriteStringValue("O");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}