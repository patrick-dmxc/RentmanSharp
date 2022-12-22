using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.StockLocation;

namespace RentmanSharp.Entity
{
    public class EStockLocationTypeConverter : JsonConverter<EStockLocationType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EStockLocationType);
        }

        public override EStockLocationType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "plannable":
                    return EStockLocationType.Plannable;
                case "nonplannable":
                    return EStockLocationType.NonPlannable;
            }
            return (EStockLocationType)Enum.Parse(typeof(EStockLocationType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, EStockLocationType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case EStockLocationType.Plannable:
                    writer.WriteStringValue("plannable");
                    break;
                case EStockLocationType.NonPlannable:
                    writer.WriteStringValue("nonplannable");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}