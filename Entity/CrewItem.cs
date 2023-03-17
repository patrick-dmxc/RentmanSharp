namespace RentmanSharp.Entity
{
    public class CrewItem : AbstractEntity
    {
        [JsonPropertyName("folder")]
        public string? Folder { get; }
        [JsonPropertyName("street")]
        public string? Street { get; }
        [JsonPropertyName("housenumber")]
        public string? Housenumber { get; }
        [JsonPropertyName("city")]
        public string? City { get; }
        [JsonPropertyName("postal_code")]
        public string? Postal_code { get; }
        [JsonPropertyName("addressline2")]
        public string? Addressline2 { get; }
        [JsonPropertyName("state")]
        public string? State { get; }
        [JsonPropertyName("country")]
        public string? Country { get; }
        [JsonPropertyName("birthdate")]
        public string? Birthdate { get; }
        [JsonPropertyName("passport_number")]
        public string? Passport_Number { get; }
        [JsonPropertyName("emergency_contact")]
        public string? Emergency_Contact { get; }
        [JsonPropertyName("remark")]
        public string? Remark { get; }
        [JsonPropertyName("driving_license")]
        public string? Driving_License { get; }
        [JsonPropertyName("contract")]
        public int Contract { get; }
        [JsonPropertyName("bank")]
        public string? Bank { get; }
        [JsonPropertyName("contract_date")]
        public string? Contract_Date { get; }
        [JsonPropertyName("company_name")]
        public string? Company_Name { get; }
        [JsonPropertyName("vat_code")]
        public string? VAT_Code { get; }
        [JsonPropertyName("coc_code")]
        public string? COC_Code { get; }
        [JsonPropertyName("firstname")]
        public string? Firstname { get; }
        [JsonPropertyName("middle_name")]
        public string? Middle_name { get; }
        [JsonPropertyName("lastname")]
        public string? Lastname { get; }
        [JsonPropertyName("email")]
        public string? Email { get; }
        [JsonPropertyName("phone")]
        public string? Phone { get; }
        [JsonPropertyName("active")]
        public bool Active { get; }
        [JsonPropertyName("avatar")]
        public string? Avatar { get; }
        [JsonPropertyName("vt_fullname")]
        public string? VT_Fullname { get; }
        [JsonPropertyName("function")]
        public string? Function { get; }
        [JsonPropertyName("tags")]
        public string? Tags { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public CrewItem(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                        string? updateHash, string? folder, string? street, string? housenumber, string? city,
                        string? postal_code, string? addressline2, string? state, string? country, string? birthdate,
                        string? passport_Number, string? emergency_Contact, string? remark, string? driving_License,
                        int contract, string? bank, string? contract_Date, string? company_Name, string? vAT_Code,
                        string? cOC_Code, string? firstname, string? middle_name, string? lastname, string? email,
                        string? phone, bool active, string? avatar, string? vT_Fullname, string? function, string? tags,
                        JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Folder = folder;
            Street = street;
            Housenumber = housenumber;
            City = city;
            Postal_code = postal_code;
            Addressline2 = addressline2;
            State = state;
            Country = country;
            Birthdate = birthdate;
            Passport_Number = passport_Number;
            Emergency_Contact = emergency_Contact;
            Remark = remark;
            Driving_License = driving_License;
            Contract = contract;
            Bank = bank;
            Contract_Date = contract_Date;
            Company_Name = company_Name;
            VAT_Code = vAT_Code;
            COC_Code = cOC_Code;
            Firstname = firstname;
            Middle_name = middle_name;
            Lastname = lastname;
            Email = email;
            Phone = phone;
            Active = active;
            Avatar = avatar;
            VT_Fullname = vT_Fullname;
            Function = function;
            Tags = tags;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"Crew\t{ID}\t{DisplayName} {Phone} {Email}";
        }
    }
}
