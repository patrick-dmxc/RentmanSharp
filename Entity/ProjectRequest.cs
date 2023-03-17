namespace RentmanSharp.Entity
{
    public class ProjectRequest : AbstractEntity
    {
        [JsonPropertyName("linked_contact")]
        public string Linked_Contact { get; }
        [JsonPropertyName("contact_mailing_number")]
        public string Contact_Mailing_Number { get; }
        [JsonPropertyName("contact_mailing_country")]
        public string Contact_Mailing_Country { get; }
        [JsonPropertyName("contact_name")]
        public string Contact_Name { get; }
        [JsonPropertyName("contact_mailing_postalcode")]
        public string Contact_Mailing_Postalcode { get; }
        [JsonPropertyName("contact_mailing_city")]
        public string Contact_Mailing_City { get; }
        [JsonPropertyName("contact_mailing_street")]
        public string Contact_Mailing_Street { get; }
        [JsonPropertyName("linked_contact_person")]
        public string Linked_Contact_Person { get; }
        [JsonPropertyName("contact_person_lastname")]
        public string Contact_Person_Lastname { get; }
        [JsonPropertyName("contact_person_email")]
        public string Contact_Person_Email { get; }
        [JsonPropertyName("contact_person_middle_name")]
        public string Contact_Person_Middle_name { get; }
        [JsonPropertyName("contact_person_first_name")]
        public string Contact_Person_First_name { get; }
        [JsonPropertyName("usageperiod_start")]
        public DateTime Usageperiod_Start { get; }
        [JsonPropertyName("usageperiod_end")]
        public DateTime Usageperiod_End { get; }
        [JsonPropertyName("is_paid")]
        public bool Is_Paid { get; }
        [JsonPropertyName("language")]
        public string Language { get; }
        [JsonPropertyName("in")]
        public DateTime @In { get; }
        [JsonPropertyName("out")]
        public DateTime @Out { get; }
        [JsonPropertyName("linked_location")]
        public string Linked_Location { get; }
        [JsonPropertyName("location_mailing_number")]
        public string Location_Mailing_Number { get; }
        [JsonPropertyName("location_mailing_country")]
        public string Location_Mailing_Country { get; }
        [JsonPropertyName("location_name")]
        public string Location_Name { get; }
        [JsonPropertyName("location_mailing_postalcode")]
        public string Location_Mailing_Postalcode { get; }
        [JsonPropertyName("location_mailing_city")]
        public string Location_Mailing_City { get; }
        [JsonPropertyName("location_mailing_street")]
        public string Location_Mailing_Street { get; }
        [JsonPropertyName("name")]
        public string Name { get; }
        [JsonPropertyName("external_reference")]
        public int External_Reference { get; }
        [JsonPropertyName("remark")]
        public string Remark { get; }
        [JsonPropertyName("planperiod_start")]
        public DateTime Planperiod_Start { get; }
        [JsonPropertyName("planperiod_end")]
        public DateTime Planperiod_End { get; }
        [JsonPropertyName("price")]
        public double Price { get; }
        [JsonPropertyName("linked_project")]
        public string Linked_Project { get; }
        [JsonPropertyName("source")]
        [JsonConverter(typeof(ESourceConverter))]
        public ESource Source { get; }
        [JsonPropertyName("status")]
        [JsonConverter(typeof(EStatusConverter))]
        public EStatus Status { get; }

        [JsonConstructor]
        public ProjectRequest(uint id, DateTime created, DateTime modified, string creator, string displayName,
                              string updateHash, string linked_Contact, string contact_Mailing_Number,
                              string contact_Mailing_Country, string contact_Name, string contact_Mailing_Postalcode,
                              string contact_Mailing_City, string contact_Mailing_Street,
                              string linked_Contact_Person, string contact_Person_Lastname,
                              string contact_Person_Email, string contact_Person_Middle_name,
                              string contact_Person_First_name, DateTime usageperiod_Start, DateTime usageperiod_End,
                              bool is_Paid, string language, DateTime @in, DateTime @out, string linked_Location,
                              string location_Mailing_Number, string location_Mailing_Country, string location_Name,
                              string location_Mailing_Postalcode, string location_Mailing_City,
                              string location_Mailing_Street, string name, int external_Reference, string remark,
                              DateTime planperiod_Start, DateTime planperiod_End, double price, string linked_Project,
                              ESource source, EStatus status) : base(id, created, modified, creator, displayName, updateHash)
        {
            Linked_Contact = linked_Contact;
            Contact_Mailing_Number = contact_Mailing_Number;
            Contact_Mailing_Country = contact_Mailing_Country;
            Contact_Name = contact_Name;
            Contact_Mailing_Postalcode = contact_Mailing_Postalcode;
            Contact_Mailing_City = contact_Mailing_City;
            Contact_Mailing_Street = contact_Mailing_Street;
            Linked_Contact_Person = linked_Contact_Person;
            Contact_Person_Lastname = contact_Person_Lastname;
            Contact_Person_Email = contact_Person_Email;
            Contact_Person_Middle_name = contact_Person_Middle_name;
            Contact_Person_First_name = contact_Person_First_name;
            Usageperiod_Start = usageperiod_Start;
            Usageperiod_End = usageperiod_End;
            Is_Paid = is_Paid;
            Language = language;
            @In = @in;
            @Out = @out;
            Linked_Location = linked_Location;
            Location_Mailing_Number = location_Mailing_Number;
            Location_Mailing_Country = location_Mailing_Country;
            Location_Name = location_Name;
            Location_Mailing_Postalcode = location_Mailing_Postalcode;
            Location_Mailing_City = location_Mailing_City;
            Location_Mailing_Street = location_Mailing_Street;
            Name = name;
            External_Reference = external_Reference;
            Remark = remark;
            Planperiod_Start = planperiod_Start;
            Planperiod_End = planperiod_End;
            Price = price;
            Linked_Project = linked_Project;
            Source = source;
            Status = status;
        }

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