using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class TaxClass : AbstractEntity
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public ETaxClassType Type { get; set; }

        public override string ToString()
        {
            return $"TaxClass\t{ID}\t{Code}\t{Name}";
        }
        [JsonConverter(typeof(ETaxClassTypeConverter))]
        public enum ETaxClassType
        {
            VAT,
            Tax,
            NoTax
        }
    }
}