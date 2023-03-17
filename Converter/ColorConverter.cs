using System.Drawing;

namespace RentmanSharp.Converter
{
    public class ColorConverter : JsonConverter<Color>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Color);
        }

        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return ColorTranslator.FromHtml($"#{reader.GetString()}");
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(ColorTranslator.ToHtml(value).Replace("#", ""));
        }
    }
}
