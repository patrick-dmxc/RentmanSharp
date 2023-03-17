namespace RentmanSharp.Entity
{
    public class ContactPerson : AbstractEntity
    {
        [JsonPropertyName("longitude")]
        public int Longitude { get; }
        [JsonPropertyName("latitude")]
        public int Latitude { get; }
        [JsonPropertyName("contact")]
        public string Contact { get; }
        [JsonPropertyName("firstname")]
        public string Firstname { get; }
        [JsonPropertyName("middle_name")]
        public string Middle_name { get; }
        [JsonPropertyName("lastname")]
        public string Lastname { get; }
        [JsonPropertyName("function")]
        public string Function { get; }
        [JsonPropertyName("remark")]
        public string Remark { get; }
        [JsonPropertyName("fax")]
        public string Fax { get; }
        [JsonPropertyName("phone")]
        public string Phone { get; }
        [JsonPropertyName("street")]
        public string Street { get; }
        [JsonPropertyName("number")]
        public string Number { get; }
        [JsonPropertyName("postalcode")]
        public string Postalcode { get; }
        [JsonPropertyName("city")]
        public string City { get; }
        [JsonPropertyName("state")]
        public string State { get; }
        [JsonPropertyName("country")]
        public string Country { get; }
        [JsonPropertyName("mobilephone")]
        public string Mobilephone { get; }
        [JsonPropertyName("email")]
        public string Email { get; }
        [JsonPropertyName("tags")]
        public string Tags { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public ContactPerson(uint id, DateTime created, DateTime modified, string creator, string displayName,
                             string updateHash, int longitude, int latitude, string contact, string firstname,
                             string middle_name, string lastname, string function, string remark, string fax,
                             string phone, string street, string number, string postalcode, string city,
                             string state, string country, string mobilephone, string email, string tags,
                             JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Longitude = longitude;
            Latitude = latitude;
            Contact = contact;
            Firstname = firstname;
            Middle_name = middle_name;
            Lastname = lastname;
            Function = function;
            Remark = remark;
            Fax = fax;
            Phone = phone;
            Street = street;
            Number = number;
            Postalcode = postalcode;
            City = city;
            State = state;
            Country = country;
            Mobilephone = mobilephone;
            Email = email;
            Tags = tags;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"Contactperson\t{ID}\t{DisplayName} Phone:{Phone} MobilePhone:{Mobilephone} EMail:{Email}";
        }
    }
}