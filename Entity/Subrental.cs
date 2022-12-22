using System.Text.Json;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class Subrental : AbstractEntity
    {
        public string? Name { get; set; }
        public string? Account_Manager { get; set; }
        public string? Reference { get; set; }
        public string? Supplier { get; set; }
        public int? Number { get; set; }
        public string? Location { get; set; }
        public string? ContactPerson { get; set; }
        public DateTime? Usageperiod_Start { get; set; }
        public DateTime? Usageperiod_End { get; set; }
        public DateTime? Planperiod_Start { get; set; }
        public DateTime? Planperiod_End { get; set; }
        public DateTime? Delivery_In { get; set; }
        public DateTime? Delivery_Out { get; set; }
        public double Equipment_Cost { get; set; }
        public double Price { get; set; }
        public double Extra_Cost { get; set; }
        public bool Auto_Update_Costs { get; set; }
        public string? Remark { get; set; }
        public ESubrentalType Type { get; set; }
        public string? Status { get; set; }
        public string? Sent { get; set; }
        public string? Asset_Location_To { get; set; }
        public string? Asset_Location_From { get; set; }
        public bool Is_Internal { get; set; }
        public string? Supplier_Project { get; set; }
        public string? Tags { get; set; }
        public JsonElement Custom { get; set; }

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