using System.Text.Json;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class Cost : AbstractEntity
    {
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("remark")]
        public string? Remark { get; }
        [JsonPropertyName("project")]
        public string? Project { get; }
        [JsonPropertyName("subproject")]
        public string? Subproject { get; }
        [JsonPropertyName("is_template")]
        public bool Is_Template { get; }
        [JsonPropertyName("taxclass")]
        public string? Taxclass { get; }
        [JsonPropertyName("ledger")]
        public string? Ledger { get; }
        [JsonPropertyName("verkoopprijs")]
        public double SellingPrice { get; }
        [JsonPropertyName("inkoopprijs")]
        public double PurchasingPrice { get; }
        [JsonPropertyName("price")]
        public double Price { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public Cost(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
            string? updateHash, string? name, string? remark, string? project, string? subproject, bool is_Template,
            string? taxclass, string? ledger, double sellingPrice, double purchasingPrice, double price,
            JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Name = name;
            Remark = remark;
            Project = project;
            Subproject = subproject;
            Is_Template = is_Template;
            Taxclass = taxclass;
            Ledger = ledger;
            SellingPrice = sellingPrice;
            PurchasingPrice = purchasingPrice;
            Price = price;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"Cost\t{ID}\t{DisplayName} {Price}EUR {SellingPrice}EUR {PurchasingPrice}EUR";
        }
    }
}
