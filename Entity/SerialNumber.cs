using System.Text.Json;

namespace RentmanSharp.Entity
{
    public class SerialNumber : AbstractEntity
    {
        public string? Equipment { get; set; }
        public string? Serial { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public double? Depreciation_Monthly { get; set; }
        public double? Book_Value { get; set; }
        public double? Purchase_Costs { get; set; }
        public bool? Active { get; set; }
        public string? Remark { get; set; }
        public string? Ref { get; set; }
        public string? Asset_Location { get; set; }
        public double? Current_Book_Value { get; set; }
        public DateTime? Next_Inspection { get; set; }
        public string? QRCodes { get; set; }
        public string? Tags { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"SerialNumber\t{ID}\t{QRCodes}\t{Serial}\t{Ref}\t{Book_Value}EUR\tActive:{Active}";
        }
    }
}