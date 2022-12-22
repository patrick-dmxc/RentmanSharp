using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.Rate;

namespace RentmanSharp.Entity
{
    public class ERateSubTypeConverter : JsonConverter<ERateSubType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ERateSubType);
        }

        public override ERateSubType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "global":
                    return ERateSubType.Global;
                case "flat":
                    return ERateSubType.Flat;
                case "temp":
                    return ERateSubType.Temp;
            }
            return (ERateSubType)Enum.Parse(typeof(ERateSubType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, ERateSubType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case ERateSubType.Global:
                    writer.WriteStringValue("global");
                    break;
                case ERateSubType.Flat:
                    writer.WriteStringValue("flat");
                    break;
                case ERateSubType.Temp:
                    writer.WriteStringValue("temp");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}