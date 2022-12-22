using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class ProjectRequest : AbstractEntity
    {
        public string? Linked_Contact { get; set; }
        public string? Contact_Mailing_Number { get; set; }
        public string? Contact_Mailing_Country { get; set; }
        public string? Contact_Name { get; set; }
        public string? Contact_Mailing_Postalcode { get; set; }
        public string? Contact_Mailing_City { get; set; }
        public string? Contact_Mailing_Street { get; set; }
        public string? Linked_Contact_Person { get; set; }
        public string? Contact_Person_Lastname { get; set; }
        public string? Contact_Person_Email { get; set; }
        public string? Contact_Person_Middle_name { get; set; }
        public string? Contact_Person_First_name { get; set; }
        public DateTime? Usageperiod_Start { get; set; }
        public DateTime? Usageperiod_End { get; set; }
        public bool? Is_Paid { get; set; }
        public string? Language { get; set; }
        public DateTime? In { get; set; }
        public DateTime? Out { get; set; }
        public string? Linked_Location { get; set; }
        public string? Location_Mailing_Number { get; set; }
        public string? Location_Mailing_Country { get; set; }
        public string? Location_Name { get; set; }
        public string? Location_Mailing_Postalcode { get; set; }
        public string? Location_Mailing_City { get; set; }
        public string? Location_Mailing_Street { get; set; }
        public string? Name { get; set; }
        public int? External_Reference { get; set; }
        public string? Remark { get; set; }
        public DateTime Planperiod_Start { get; set; }
        public DateTime Planperiod_End { get; set; }
        public double? Price { get; set; }
        public string? Linked_Project { get; set; }
        [JsonConverter(typeof(ESourceConverter))]
        public ESource? Source { get; set; }
        [JsonConverter(typeof(EStatusConverter))]
        public EStatus? Status { get; set; }

        public override string ToString()
        {
            return $"ProjectRequest\t{ID}\t{DisplayName} ";
        }

        public enum ESource
        {
            rentaround,
            rentman,
            zoef,
            api
        }
        public enum EStatus
        {
            accepted,
            declined,
            open
        }
    }
}