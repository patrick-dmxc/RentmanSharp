using static RentmanSharp.Entity.ProjectRequest;

namespace RentmanSharp.Entity
{
    public class ESourceConverter : JsonConverter<ESource>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ESource);
        }

        public override ESource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            return (ESource)Enum.Parse(typeof(ESource), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, ESource value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}