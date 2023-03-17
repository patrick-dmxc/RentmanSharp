namespace RentmanSharp.Entity
{
    public class SerialNumber : AbstractEntity
    {
        [JsonPropertyName("equipment")]
        public string? Equipment { get; }
        [JsonPropertyName("serial")]
        public string? Serial { get; }
        [JsonPropertyName("purchasedate")]
        public DateTime? PurchaseDate { get; }
        [JsonPropertyName("depreciation_monthly")]
        public double? Depreciation_Monthly { get; }
        [JsonPropertyName("book_value")]
        public double? Book_Value { get; }
        [JsonPropertyName("purchase_costs")]
        public double? Purchase_Costs { get; }
        [JsonPropertyName("active")]
        public bool? Active { get; }
        [JsonPropertyName("remark")]
        public string? Remark { get; }
        [JsonPropertyName("ref")]
        public string? Ref { get; }
        [JsonPropertyName("asset_location")]
        public string? Asset_Location { get; }
        [JsonPropertyName("current_book_value")]
        public double? Current_Book_Value { get; }
        [JsonPropertyName("next_inspection")]
        public DateTime? Next_Inspection { get; }
        [JsonPropertyName("qrcodes")]
        public string? QRCodes { get; }
        [JsonPropertyName("tags")]
        public string? Tags { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public SerialNumber(
            uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName, string? updateHash,
            string? equipment, string? serial, DateTime? purchaseDate, double? depreciation_Monthly, double? book_Value,
            double? purchase_Costs, bool? active, string? remark, string? @ref, string? asset_Location,
            double? current_Book_Value, DateTime? next_Inspection, string? qRCodes, string? tags, JsonElement custom)
            : base(id, created, modified, creator, displayName, updateHash)
        {
            Equipment = equipment;
            Serial = serial;
            PurchaseDate = purchaseDate;
            Depreciation_Monthly = depreciation_Monthly;
            Book_Value = book_Value;
            Purchase_Costs = purchase_Costs;
            Active = active;
            Remark = remark;
            Ref = @ref;
            Asset_Location = asset_Location;
            Current_Book_Value = current_Book_Value;
            Next_Inspection = next_Inspection;
            QRCodes = qRCodes;
            Tags = tags;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"SerialNumber\t{ID}\t{QRCodes}\t{Serial}\t{Ref}\t{Book_Value}EUR\tActive:{Active}";
        }
    }
}