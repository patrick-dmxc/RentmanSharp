using System.Text.Json;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class Contact: AbstractEntity
    {
        [JsonPropertyName("folder")]
        public string? Folder { get; }
        [JsonPropertyName("type")]
        public string? Type { get; }
        [JsonPropertyName("ext_name_line")]
        public string? Ext_Name_Line { get; }
        [JsonPropertyName("firstname")]
        public string? FirstName { get; }
        [JsonPropertyName("distance")]
        public int? Distance { get; }
        [JsonPropertyName("travel_time")]
        public int? Travel_Time { get; }
        [JsonPropertyName("surfix")]
        public string? Surfix { get; }
        [JsonPropertyName("surname")]
        public string? Surname { get; }
        [JsonPropertyName("longitude")]
        public int? Longitude { get; }
        [JsonPropertyName("latitude")]
        public int? Latitude { get; }
        [JsonPropertyName("code")]
        public string? Code { get; }
        [JsonPropertyName("accounting_code")]
        public string? Accounting_Code { get; }
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("gender")]
        public string? Gender { get; }
        [JsonPropertyName("mailing_city")]
        public string? Mailing_City { get; }
        [JsonPropertyName("mailing_street")]
        public string? Mailing_Street { get; }
        [JsonPropertyName("mailing_number")]
        public string? Mailing_Number { get; }
        [JsonPropertyName("mailing_postalcode")]
        public string? Mailing_Postalcode { get; }
        [JsonPropertyName("mailing_state")]
        public string? Mailing_State { get; }
        [JsonPropertyName("mailing_country")]
        public string? Mailing_Country { get; }
        [JsonPropertyName("visit_city")]
        public string? Visit_City { get; }
        [JsonPropertyName("visit_street")]
        public string? Visit_Street { get; }
        [JsonPropertyName("visit_number")]
        public string? Visit_Number { get; }
        [JsonPropertyName("visit_postalcode")]
        public string? Visit_Postalcode { get; }
        [JsonPropertyName("visit_state")]
        public string? Visit_State { get; }
        [JsonPropertyName("country")]
        public string? Country { get; }
        [JsonPropertyName("invoice_city")]
        public string? Invoice_City { get; }
        [JsonPropertyName("invoice_street")]
        public string? Invoice_Street { get; }
        [JsonPropertyName("invoice_number")]
        public string? Invoice_Number { get; }
        [JsonPropertyName("invoice_postalcode")]
        public string? Invoice_Postalcode { get; }
        [JsonPropertyName("invoice_state")]
        public string? Invoice_State { get; }
        [JsonPropertyName("invoice_country")]
        public string? Invoice_Country { get; }
        [JsonPropertyName("phone_1")]
        public string? Phone_1 { get; }
        [JsonPropertyName("phone_2")]
        public string? Phone_2 { get; }
        [JsonPropertyName("fax")]
        public string? Fax { get; }
        [JsonPropertyName("email_1")]
        public string? Email_1 { get; }
        [JsonPropertyName("email_2")]
        public string? Email_2 { get; }
        [JsonPropertyName("website")]
        public string? Website { get; }
        [JsonPropertyName("vat_code")]
        public string? VAT_code { get; }
        [JsonPropertyName("fiscal_code")]
        public string? Fiscal_code { get; }
        [JsonPropertyName("commerce_code")]
        public string? Commerce_code { get; }
        [JsonPropertyName("purchase_number")]
        public string? Purchase_number { get; }
        [JsonPropertyName("bic")]
        public string? BIC { get; }
        [JsonPropertyName("bank_account")]
        public string? Bank_Account { get; }
        [JsonPropertyName("default_person")]
        public string? Default_Person { get; }
        [JsonPropertyName("admin_contactperson")]
        public string? Admin_Contactperson { get; }
        [JsonPropertyName("discount_crew")]
        public double? Discount_Crew { get; }
        [JsonPropertyName("discount_transport")]
        public double? Discount_Transport { get; }
        [JsonPropertyName("discount_rental")]
        public double? Discount_Rental { get; }
        [JsonPropertyName("discount_sale")]
        public double? Discount_Sale { get; }
        [JsonPropertyName("discount_total")]
        public double? Discount_Total { get; }
        [JsonPropertyName("discount_subrent")]
        public double? Discount_Subrent { get; }
        [JsonPropertyName("projectnote")]
        public string? ProjectNote { get; }
        [JsonPropertyName("projectNote_title")]
        public string? ProjectNote_Title { get; }
        [JsonPropertyName("contact_warning")]
        public string? Contact_Warning { get; }
        [JsonPropertyName("tags")]
        public string? Tags { get; }
        [JsonPropertyName("custom")]
        public JsonElement? Custom { get; }

        [JsonConstructor]
        public Contact(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                       string? updateHash, string? folder, string? type, string? ext_Name_Line, string? firstName,
                       int? distance, int? travel_Time, string? surfix, string? surname, int? longitude, int? latitude,
                       string? code, string? accounting_Code, string? name, string? gender, string? mailing_City,
                       string? mailing_Street, string? mailing_Number, string? mailing_Postalcode, string? mailing_State,
                       string? mailing_Country, string? visit_City, string? visit_Street, string? visit_Number,
                       string? visit_Postalcode, string? visit_State, string? country, string? invoice_City,
                       string? invoice_Street, string? invoice_Number, string? invoice_Postalcode, string? invoice_State,
                       string? invoice_Country, string? phone_1, string? phone_2, string? fax, string? email_1,
                       string? email_2, string? website, string? vat_code, string? fiscal_code, string? commerce_code,
                       string? purchase_number, string? bic, string? bank_Account, string? default_Person,
                       string? admin_Contactperson, double? discount_Crew, double? discount_Transport,
                       double? discount_Rental, double? discount_Sale, double? discount_Total, double? discount_Subrent,
                       string? projectNote, string? projectNote_Title, string? contact_Warning, string? tags,
                       JsonElement? custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Folder = folder;
            Type = type;
            Ext_Name_Line = ext_Name_Line;
            FirstName = firstName;
            Distance = distance;
            Travel_Time = travel_Time;
            Surfix = surfix;
            Surname = surname;
            Longitude = longitude;
            Latitude = latitude;
            Code = code;
            Accounting_Code = accounting_Code;
            Name = name;
            Gender = gender;
            Mailing_City = mailing_City;
            Mailing_Street = mailing_Street;
            Mailing_Number = mailing_Number;
            Mailing_Postalcode = mailing_Postalcode;
            Mailing_State = mailing_State;
            Mailing_Country = mailing_Country;
            Visit_City = visit_City;
            Visit_Street = visit_Street;
            Visit_Number = visit_Number;
            Visit_Postalcode = visit_Postalcode;
            Visit_State = visit_State;
            Country = country;
            Invoice_City = invoice_City;
            Invoice_Street = invoice_Street;
            Invoice_Number = invoice_Number;
            Invoice_Postalcode = invoice_Postalcode;
            Invoice_State = invoice_State;
            Invoice_Country = invoice_Country;
            Phone_1 = phone_1;
            Phone_2 = phone_2;
            Fax = fax;
            Email_1 = email_1;
            Email_2 = email_2;
            Website = website;
            VAT_code = vat_code;
            Fiscal_code = fiscal_code;
            Commerce_code = commerce_code;
            Purchase_number = purchase_number;
            BIC = bic;
            Bank_Account = bank_Account;
            Default_Person = default_Person;
            Admin_Contactperson = admin_Contactperson;
            Discount_Crew = discount_Crew;
            Discount_Transport = discount_Transport;
            Discount_Rental = discount_Rental;
            Discount_Sale = discount_Sale;
            Discount_Total = discount_Total;
            Discount_Subrent = discount_Subrent;
            ProjectNote = projectNote;
            ProjectNote_Title = projectNote_Title;
            Contact_Warning = contact_Warning;
            Tags = tags;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"Contact\t{ID}\t{DisplayName}";
        }
        [JsonConverter(typeof(EContactTypeConverter))]
        public enum EContactType
        {
            Private,
            Company
        }
    }
}
