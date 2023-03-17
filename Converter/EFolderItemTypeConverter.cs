using static RentmanSharp.Entity.Folder;

namespace RentmanSharp.Entity
{
    public class EFolderItemTypeConverter : JsonConverter<EFolderItemType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EFolderItemType);
        }

        public override EFolderItemType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "equipment":
                    return EFolderItemType.Equipment;
                case "contact":
                    return EFolderItemType.Contact;
                case "vehicle":
                    return EFolderItemType.Vehicle;
                case "user":
                    return EFolderItemType.User;
                case "container":
                    return EFolderItemType.Container;
            }
            return (EFolderItemType)Enum.Parse(typeof(EFolderItemType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, EFolderItemType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case EFolderItemType.Equipment:
                    writer.WriteStringValue("equipment");
                    break;
                case EFolderItemType.Contact:
                    writer.WriteStringValue("contact");
                    break;
                case EFolderItemType.Vehicle:
                    writer.WriteStringValue("vehicle");
                    break;
                case EFolderItemType.User:
                    writer.WriteStringValue("user");
                    break;
                case EFolderItemType.Container:
                    writer.WriteStringValue("container");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}