using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.EquipmentItem;

namespace RentmanSharp.Entity
{
    public class EEquipmentStockManagementConverter : JsonConverter<EEquipmentStockManagement>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EEquipmentStockManagement);
        }

        public override EEquipmentStockManagement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "Exclude from stock tracking":
                    return EEquipmentStockManagement.ExcludeFromStockTracking;
                case "Track stock":
                    return EEquipmentStockManagement.TrackStock;
            }
            return (EEquipmentStockManagement)Enum.Parse(typeof(EEquipmentStockManagement), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, EEquipmentStockManagement value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case EEquipmentStockManagement.ExcludeFromStockTracking:
                    writer.WriteStringValue("Exclude from stock tracking");
                    break;
                case EEquipmentStockManagement.TrackStock:
                    writer.WriteStringValue("Track stock");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}