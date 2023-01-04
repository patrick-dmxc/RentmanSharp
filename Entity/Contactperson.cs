using System.Text.Json;

namespace RentmanSharp.Entity
{
    public class ContactPerson : AbstractEntity
    {
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public string? Contact { get; set; }
        public string? Firstname { get; set; }
        public string? Middle_name { get; set; }
        public string? Lastname { get; set; }
        public string? Function { get; set; }
        public string? Remark { get; set; }
        public string? Fax { get; set; }
        public string? Phone { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Postalcode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Mobilephone { get; set; }
        public string? Email { get; set; }
        public string? Tags { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"Contactperson\t{ID}\t{DisplayName} Phone:{Phone} MobilePhone:{Mobilephone} EMail:{Email}";
        }
    }
}