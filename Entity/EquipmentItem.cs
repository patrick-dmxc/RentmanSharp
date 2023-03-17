namespace RentmanSharp.Entity
{
    public class EquipmentItem : AbstractEntity
    {
        [JsonPropertyName("folder")]
        public string Folder { get; }
        [JsonPropertyName("code")]
        public string Code { get; }
        [JsonPropertyName("name")]
        public string Name { get; }
        [JsonPropertyName("internal_remark")]
        public string Internal_Remark { get; }
        [JsonPropertyName("external_remark")]
        public string External_Remark { get; }
        [JsonPropertyName("location_in_warehouse")]
        public string Location_In_Warehouse { get; }
        [JsonPropertyName("unit")]
        public string Unit { get; }
        [JsonPropertyName("in_shop")]
        public bool In_Shop { get; }
        [JsonPropertyName("surface_article")]
        public bool Surface_Article { get; }
        [JsonPropertyName("shop_description_short")]
        public string Shop_Description_Short { get; }
        [JsonPropertyName("shop_description_long")]
        public string Shop_Description_Long { get; }
        [JsonPropertyName("shop_seo_title")]
        public string Shop_Seo_Title { get; }
        [JsonPropertyName("shop_seo_keyword")]
        public string Shop_Seo_Keyword { get; }
        [JsonPropertyName("shop_seo_description")]
        public string Shop_Seo_Description { get; }
        [JsonPropertyName("shop_featured")]
        public bool Shop_Featured { get; }
        [JsonPropertyName("price")]
        public double Price { get; }
        [JsonPropertyName("subrental_costs")]
        public double Subrental_Costs { get; }
        [JsonPropertyName("critical_stock_level")]
        public double Critical_Stock_Level { get; }
        [JsonPropertyName("type")]
        public EEquipmentType Type { get; }
        [JsonPropertyName("rental_sales")]
        public EEquipmentRentalSalesType Rental_Sales { get; }
        [JsonPropertyName("temporary")]
        public bool Temporary { get; }
        [JsonPropertyName("in_planner")]
        public bool In_Planner { get; }
        [JsonPropertyName("in_archive")]
        public bool In_Archive { get; }
        [JsonPropertyName("stock_management")]
        public EEquipmentStockManagement Stock_Management { get; }
        [JsonPropertyName("taxclass")]
        public string Taxclass { get; }
        [JsonPropertyName("list_price")]
        public double List_Price { get; }
        [JsonPropertyName("volume")]
        public double Volume { get; }
        [JsonPropertyName("packed_per")]
        public int Packed_Per { get; }
        [JsonPropertyName("height")]
        public double Height { get; }
        [JsonPropertyName("width")]
        public double Width { get; }
        [JsonPropertyName("length")]
        public double Length { get; }
        [JsonPropertyName("weight")]
        public double Weight { get; }
        [JsonPropertyName("power")]
        public double Power { get; }
        [JsonPropertyName("current")]
        public double Current { get; }
        [JsonPropertyName("country_of_origin")]
        public string Country_Of_Origin { get; }
        [JsonPropertyName("image")]
        public string Image { get; }
        [JsonPropertyName("ledger")]
        public string Ledger { get; }
        [JsonPropertyName("defaultgroup")]
        public string DefaultGroup { get; }
        [JsonPropertyName("qrcodes")]
        public string QRCodes { get; }
        [JsonPropertyName("qrcodes_of_serial_numbers")]
        public string QRCodes_Of_Serial_Numbers { get; }
        [JsonPropertyName("tags")]
        public string Tags { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public EquipmentItem(uint id, DateTime created, DateTime modified, string creator, string displayName,
            string updateHash, string folder, string code, string name, string internal_Remark,
            string external_Remark, string location_In_Warehouse, string unit, bool in_Shop, bool surface_Article,
            string shop_Description_Short, string shop_Description_Long, string shop_Seo_Title,
            string shop_Seo_Keyword, string shop_Seo_Description, bool shop_Featured, double price,
            double subrental_Costs, double critical_Stock_Level, EEquipmentType type,
            EEquipmentRentalSalesType rental_Sales, bool temporary, bool in_Planner, bool in_Archive,
            EEquipmentStockManagement stock_Management, string taxclass, double list_Price, double volume,
            int packed_Per, double height, double width, double length, double weight, double power, double current,
            string country_Of_Origin, string image, string ledger, string defaultGroup, string qRCodes,
            string qRCodes_Of_Serial_Numbers, string tags, JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Folder = folder;
            Code = code;
            Name = name;
            Internal_Remark = internal_Remark;
            External_Remark = external_Remark;
            Location_In_Warehouse = location_In_Warehouse;
            Unit = unit;
            In_Shop = in_Shop;
            Surface_Article = surface_Article;
            Shop_Description_Short = shop_Description_Short;
            Shop_Description_Long = shop_Description_Long;
            Shop_Seo_Title = shop_Seo_Title;
            Shop_Seo_Keyword = shop_Seo_Keyword;
            Shop_Seo_Description = shop_Seo_Description;
            Shop_Featured = shop_Featured;
            Price = price;
            Subrental_Costs = subrental_Costs;
            Critical_Stock_Level = critical_Stock_Level;
            Type = type;
            Rental_Sales = rental_Sales;
            Temporary = temporary;
            In_Planner = in_Planner;
            In_Archive = in_Archive;
            Stock_Management = stock_Management;
            Taxclass = taxclass;
            List_Price = list_Price;
            Volume = volume;
            Packed_Per = packed_Per;
            Height = height;
            Width = width;
            Length = length;
            Weight = weight;
            Power = power;
            Current = current;
            Country_Of_Origin = country_Of_Origin;
            Image = image;
            Ledger = ledger;
            DefaultGroup = defaultGroup;
            QRCodes = qRCodes;
            QRCodes_Of_Serial_Numbers = qRCodes_Of_Serial_Numbers;
            Tags = tags;
            Custom = custom;
        }

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