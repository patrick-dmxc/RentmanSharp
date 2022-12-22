using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.ProjectVehicle;

namespace RentmanSharp.Entity
{
    public class ETransportConverter : JsonConverter<ETransport>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ETransport);
        }

        public override ETransport Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "No transport":
                    return ETransport.NoTransport;
                case "Round trip":
                    return ETransport.RoundTrip;
                case "Only way there":
                    return ETransport.OnlyWayThere;
                case "Only way back":
                    return ETransport.OnlyWayBack;
            }
            return (ETransport)Enum.Parse(typeof(ETransport), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, ETransport value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case ETransport.NoTransport:
                    writer.WriteStringValue("No transport");
                    break;
                case ETransport.RoundTrip:
                    writer.WriteStringValue("Round trip");
                    break;
                case ETransport.OnlyWayThere:
                    writer.WriteStringValue("Only way there");
                    break;
                case ETransport.OnlyWayBack:
                    writer.WriteStringValue("Only way back");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}