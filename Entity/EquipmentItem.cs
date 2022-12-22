using System.Text.Json;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class EquipmentItem : AbstractEntity
    {
        public string? Folder { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Internal_Remark { get; set; }
        public string? External_Remark { get; set; }
        public string? Location_In_Warehouse { get; set; }
        public string? Unit { get; set; }
        public bool In_Shop { get; set; }
        public bool Surface_Article { get; set; }
        public string? Shop_Description_Short { get; set; }
        public string? Shop_Description_Long { get; set; }
        public string? Shop_Seo_Title { get; set; }
        public string? Shop_Seo_Keyword { get; set; }
        public string? Shop_Seo_Description { get; set; }
        public bool Shop_Featured { get; set; }
        public double Price { get; set; }
        public double Subrental_Costs { get; set; }
        public double Critical_Stock_Level { get; set; }
        public EEquipmentType? Type { get; set; }
        public EEquipmentRentalSalesType? Rental_Sales { get; set; }
        public bool Temporary { get; set; }
        public bool In_Planner { get; set; }
        public bool In_Archive { get; set; }
        public EEquipmentStockManagement? Stock_Management { get; set; }
        public string? Taxclass { get; set; }
        public double List_Price { get; set; }
        public double Volume { get; set; }
        public int Packed_Per { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public double Power { get; set; }
        public double Current { get; set; }
        public string? Country_Of_Origin { get; set; }
        public string? Image { get; set; }
        public string? Ledger { get; set; }
        public string? DefaultGroup { get; set; }
        public string? QRCodes { get; set; }
        public string? QRCodes_Of_Serial_Numbers { get; set; }
        public string? Tags { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"Equipment\t{ID}\t{DisplayName}";
        }
        [JsonConverter(typeof(EEquipmentTypeConverter))]
        public enum EEquipmentType
        {
            Set,
            Case,
            Item
        }
        [JsonConverter(typeof(EEquipmentRentalSalesTypeConverter))]
        public enum EEquipmentRentalSalesType
        {
            Sale,
            Rental
        }
        [JsonConverter(typeof(EEquipmentStockManagementConverter))]
        public enum EEquipmentStockManagement
        {
            ExcludeFromStockTracking,
            TrackStock
        }
    }
}