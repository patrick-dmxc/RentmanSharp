using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.Subrental;

namespace RentmanSharp.Entity
{
    public class ESubrentalTypeConverter : JsonConverter<ESubrentalType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ESubrentalType);
        }

        public override ESubrentalType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "Pick up":
                    return ESubrentalType.PickUp;
                case "Delivery at warehouse":
                    return ESubrentalType.DeliveryAtWarehouse;
                case "Delivery at location":
                    return ESubrentalType.DeliveryAtLocation;
            }
            return (ESubrentalType)Enum.Parse(typeof(ESubrentalType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, ESubrentalType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case ESubrentalType.PickUp:
                    writer.WriteStringValue("Pick up");
                    break;
                case ESubrentalType.DeliveryAtWarehouse:
                    writer.WriteStringValue("Delivery at warehouse");
                    break;
                case ESubrentalType.DeliveryAtLocation:
                    writer.WriteStringValue("Delivery at location");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}