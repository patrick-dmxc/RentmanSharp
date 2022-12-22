using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.EquipmentItem;

namespace RentmanSharp.Entity
{
    public class EEquipmentRentalSalesTypeConverter : JsonConverter<EEquipmentRentalSalesType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EEquipmentRentalSalesType);
        }

        public override EEquipmentRentalSalesType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "Sale":
                    return EEquipmentRentalSalesType.Sale;
                case "Rental":
                    return EEquipmentRentalSalesType.Rental;
            }
            return (EEquipmentRentalSalesType)Enum.Parse(typeof(EEquipmentRentalSalesType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, EEquipmentRentalSalesType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case EEquipmentRentalSalesType.Sale:
                    writer.WriteStringValue("Sale");
                    break;
                case EEquipmentRentalSalesType.Rental:
                    writer.WriteStringValue("Rental");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}