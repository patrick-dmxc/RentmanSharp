using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.ProjectRequest;

namespace RentmanSharp.Entity
{
    public class EStatusConverter : JsonConverter<EStatus>
    {
        public EStatusConverter() : base() { }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EStatus);
        }

        public override EStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            return (EStatus)Enum.Parse(typeof(EStatus), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, EStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}