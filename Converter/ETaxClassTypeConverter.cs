using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.TaxClass;

namespace RentmanSharp.Entity
{
    public class ETaxClassTypeConverter : JsonConverter<ETaxClassType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ETaxClassType);
        }

        public override ETaxClassType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "vat":
                    return ETaxClassType.VAT;
                case "tax":
                    return ETaxClassType.Tax;
                case "notax":
                    return ETaxClassType.NoTax;
            }
            return (ETaxClassType)Enum.Parse(typeof(ETaxClassType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, ETaxClassType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case ETaxClassType.VAT:
                    writer.WriteStringValue("vat");
                    break;
                case ETaxClassType.Tax:
                    writer.WriteStringValue("tax");
                    break;
                case ETaxClassType.NoTax:
                    writer.WriteStringValue("notax");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}