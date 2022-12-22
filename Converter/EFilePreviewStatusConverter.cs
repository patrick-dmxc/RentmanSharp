using System.Text.Json;
using System.Text.Json.Serialization;
using static RentmanSharp.Entity.File;

namespace RentmanSharp.Entity
{
    public class EFilePreviewStatusConverter : JsonConverter<EFilePreviewStatus>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EFilePreviewStatus);
        }

        public override EFilePreviewStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "no":
                    return EFilePreviewStatus.No;
                case "yes":
                    return EFilePreviewStatus.Yes;
                case "failed":
                    return EFilePreviewStatus.Failed;
            }
            return (EFilePreviewStatus)Enum.Parse(typeof(EFilePreviewStatus), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, EFilePreviewStatus value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case EFilePreviewStatus.No:
                    writer.WriteStringValue("no");
                    break;
                case EFilePreviewStatus.Yes:
                    writer.WriteStringValue("yes");
                    break;
                case EFilePreviewStatus.Failed:
                    writer.WriteStringValue("failed");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}