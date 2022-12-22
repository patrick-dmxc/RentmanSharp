using System.Text.Json;

namespace RentmanSharp.Entity
{
    public class Contact: AbstractEntity
    {
        public string? Folder { get; set; }
        public string? Type { get; set; }
        public string? Ext_Name_Line { get; set; }
        public string? FirstName { get; set; }
        public int Distance { get; set; }
        public int Travel_Time { get; set; }
        public string? Surfix { get; set; }
        public string? Surname { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public string? Code { get; set; }
        public string? Accounting_Code { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Mailing_City { get; set; }
        public string? Mailing_Street { get; set; }
        public string? Mailing_Number { get; set; }
        public string? Mailing_Postalcode { get; set; }
        public string? Mailing_State { get; set; }
        public string? Mailing_Country { get; set; }
        public string? Visit_City { get; set; }
        public string? Visit_Street { get; set; }
        public string? Visit_Number { get; set; }
        public string? Visit_Postalcode { get; set; }
        public string? Visit_State { get; set; }
        public string? Country { get; set; }
        public string? Invoice_City { get; set; }
        public string? Invoice_Street { get; set; }
        public string? Invoice_Number { get; set; }
        public string? Invoice_Postalcode { get; set; }
        public string? Invoice_State { get; set; }
        public string? Invoice_Country { get; set; }
        public string? Phone_1 { get; set; }
        public string? Phone_2 { get; set; }
        public string? Fax { get; set; }
        public string? Email_1 { get; set; }
        public string? Email_2 { get; set; }
        public string? Website { get; set; }
        public string? VAT_code { get; set; }
        public string? Fiscal_code { get; set; }
        public string? Commerce_code { get; set; }
        public string? Purchase_number { get; set; }
        public string? BIC { get; set; }
        public string? Bank_Account { get; set; }
        public string? Default_Person { get; set; }
        public string? Admin_Contactperson { get; set; }
        public double Discount_Crew { get; set; }
        public double Discount_Transport { get; set; }
        public double Discount_Rental { get; set; }
        public double Discount_Sale { get; set; }
        public double Discount_Total { get; set; }
        public double Discount_Subrent { get; set; }
        public string? ProjectNote { get; set; }
        public string? ProjectNote_Title { get; set; }
        public string? Contact_Warning { get; set; }
        public string? Tags { get; set; }

        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"Contact\t{ID}\t{DisplayName}";
        }
    }
}
