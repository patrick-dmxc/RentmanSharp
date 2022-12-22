using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.EquipmentItem;

namespace RentmanSharp.Entity
{
    public class EEquipmentTypeConverter : JsonConverter<EEquipmentType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EEquipmentType);
        }

        public override EEquipmentType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "set":
                    return EEquipmentType.Set;
                case "case":
                    return EEquipmentType.Case;
                case "item":
                    return EEquipmentType.Item;
            }
            return (EEquipmentType)Enum.Parse(typeof(EEquipmentType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, EEquipmentType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case EEquipmentType.Set:
                    writer.WriteStringValue("set");
                    break;
                case EEquipmentType.Case:
                    writer.WriteStringValue("case");
                    break;
                case EEquipmentType.Item:
                    writer.WriteStringValue("item");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}