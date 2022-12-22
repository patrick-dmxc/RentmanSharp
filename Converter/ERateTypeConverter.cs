using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.Rate;

namespace RentmanSharp.Entity
{
    public class ERateTypeConverter : JsonConverter<ERateType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ERateType);
        }

        public override ERateType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "price":
                    return ERateType.Price;
                case "cost":
                    return ERateType.Cost;
            }
            return (ERateType)Enum.Parse(typeof(ERateType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, ERateType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case ERateType.Price:
                    writer.WriteStringValue("price");
                    break;
                case ERateType.Cost:
                    writer.WriteStringValue("cost");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}