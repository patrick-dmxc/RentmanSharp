using System.Text.Json;

namespace RentmanSharp.Entity
{
    public class CrewItem : AbstractEntity
    {
        public string? Folder { get; set; }
        public string? Street { get; set; }
        public string? Housenumber { get; set; }
        public string? City { get; set; }
        public string? Postal_code { get; set; }
        public string? Addressline2 { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Birthdate { get; set; }
        public string? Passport_Number { get; set; }
        public string? Emergency_Contact { get; set; }
        public string? Remark { get; set; }
        public string? Driving_License { get; set; }
        public int Contract { get; set; }
        public string? Bank { get; set; }
        public string? Contract_Date { get; set; }
        public string? Company_Name { get; set; }
        public string? VAT_Code { get; set; }
        public string? COC_Code { get; set; }
        public string? Firstname { get; set; }
        public string? Middle_name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool Active { get; set; }
        public string? Avatar { get; set; }
        public string? VT_Fullname { get; set; }
        public string? Function { get; set; }
        public string? Tags { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"Crew\t{ID}\t{DisplayName} {Phone} {Email}";
        }
    }
}
