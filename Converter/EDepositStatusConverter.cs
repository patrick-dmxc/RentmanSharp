using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.Project;

namespace RentmanSharp.Entity
{
    public class EDepositStatusConverter : JsonConverter<EDepositStatus>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EDepositStatus);
        }

        public override EDepositStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            return (EDepositStatus)Enum.Parse(typeof(EDepositStatus), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, EDepositStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}