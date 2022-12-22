using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.Contact;

namespace RentmanSharp.Entity
{
    public class EContactTypeConverter : JsonConverter<EContactType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EContactType);
        }

        public override EContactType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "private":
                    return EContactType.Private;
                case "company":
                    return EContactType.Company;
            }
            return (EContactType)Enum.Parse(typeof(EContactType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, EContactType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case EContactType.Private:
                    writer.WriteStringValue("private");
                    break;
                case EContactType.Company:
                    writer.WriteStringValue("company");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}