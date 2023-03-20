namespace RentmanSharp.Entity
{
    public class Subrental : AbstractEntity
    {
        [JsonPropertyName("name")]
        public string Name { get; }
        [JsonPropertyName("account_manager")]
        public string Account_Manager { get; }
        [JsonPropertyName("reference")]
        public string Reference { get; }
        [JsonPropertyName("supplier")]
        public string Supplier { get; }
        [JsonPropertyName("number")]
        public int Number { get; }
        [JsonPropertyName("location")]
        public string? Location { get; }
        [JsonPropertyName("location_contact")]
        public string? LocationContact { get; }
        [JsonPropertyName("contactperson")]
        public string? ContactPerson { get; }
        [JsonPropertyName("usageperiod_start")]
        public DateTime? Usageperiod_Start { get; }
        [JsonPropertyName("usageperiod_end")]
        public DateTime? Usageperiod_End { get; }
        [JsonPropertyName("planperiod_start")]
        public DateTime? Planperiod_Start { get; }
        [JsonPropertyName("planperiod_end")]
        public DateTime? Planperiod_End { get; }
        [JsonPropertyName("delivery_in")]
        public DateTime? Delivery_In { get; }
        [JsonPropertyName("delivery_out")]
        public DateTime? Delivery_Out { get; }
        [JsonPropertyName("equipment_cost")]
        public double Equipment_Cost { get; }
        [JsonPropertyName("price")]
        public double Price { get; }
        [JsonPropertyName("extra_cost")]
        public double Extra_Cost { get; }
        [JsonPropertyName("auto_update_costs")]
        public bool Auto_Update_Costs { get; }
        [JsonPropertyName("remark")]
        public string Remark { get; }
        [JsonPropertyName("type")]
        public ESubrentalType Type { get; }
        [JsonPropertyName("status")]
        public string Status { get; }
        [JsonPropertyName("sent")]
        public string? Sent { get; }
        [JsonPropertyName("asset_location_to")]
        public string Asset_Location_To { get; }
        [JsonPropertyName("asset_location_from")]
        public string? Asset_Location_From { get; }
        [JsonPropertyName("is_internal")]
        public bool Is_Internal { get; }
        [JsonPropertyName("supplier_project")]
        public string? Supplier_Project { get; }
        [JsonPropertyName("tags")]
        public string Tags { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public Subrental(
            uint id, DateTime created, DateTime modified, string creator, string displayName, string updateHash,
            string name, string account_Manager, string reference, string supplier, int number, string? location, string? locationContact,
            string? contactPerson, DateTime? usageperiod_Start, DateTime? usageperiod_End, DateTime? planperiod_Start,
            DateTime? planperiod_End, DateTime? delivery_In, DateTime? delivery_Out, double equipment_Cost, double price,
            double extra_Cost, bool auto_Update_Costs, string remark, ESubrentalType type, string status, string? sent,
            string asset_Location_To, string? asset_Location_From, bool is_Internal, string? supplier_Project,
            string tags, JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Name = name;
            Account_Manager = account_Manager;
            Reference = reference;
            Supplier = supplier;
            Number = number;
            Location = location;
            LocationContact = locationContact;
            ContactPerson = contactPerson;
            Usageperiod_Start = usageperiod_Start;
            Usageperiod_End = usageperiod_End;
            Planperiod_Start = planperiod_Start;
            Planperiod_End = planperiod_End;
            Delivery_In = delivery_In;
            Delivery_Out = delivery_Out;
            Equipment_Cost = equipment_Cost;
            Price = price;
            Extra_Cost = extra_Cost;
            Auto_Update_Costs = auto_Update_Costs;
            Remark = remark;
            Type = type;
            Status = status;
            Sent = sent;
            Asset_Location_To = asset_Location_To;
            Asset_Location_From = asset_Location_From;
            Is_Internal = is_Internal;
            Supplier_Project = supplier_Project;
            Tags = tags;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"Subrental\t{ID}\t{DisplayName} ";
        }
        [JsonConverter(typeof(ESubrentalTypeConverter))]
        public enum ESubrentalType
        {
            PickUp,
            DeliveryAtWarehouse,
            DeliveryAtLocation
        }
    }
}