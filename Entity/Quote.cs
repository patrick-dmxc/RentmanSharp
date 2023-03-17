namespace RentmanSharp.Entity
{
    public class Quote : AbstractEntity
    {
        [JsonPropertyName("number")]
        public string Number { get; }
        [JsonPropertyName("customer")]
        public string Customer { get; }
        [JsonPropertyName("contact")]
        public string Contact { get; }
        [JsonPropertyName("date")]
        public DateTime Date { get; }
        [JsonPropertyName("expiration_date")]
        public DateTime Expiration_Date { get; }
        [JsonPropertyName("version")]
        public int Version { get; }
        [JsonPropertyName("subject")]
        public string Subject { get; }
        [JsonPropertyName("show_Tax")]
        public bool Show_Tax { get; }
        [JsonPropertyName("project")]
        public string Project { get; }
        [JsonPropertyName("filename")]
        public string Filename { get; }
        [JsonPropertyName("price")]
        public double Price { get; }
        [JsonPropertyName("price_invat")]
        public double Price_Invat { get; }
        [JsonPropertyName("vat_amount")]
        public double Vat_Amount { get; }

        [JsonConstructor]
        public Quote(uint id, DateTime created, DateTime modified, string creator, string displayName,
            string updateHash, string number, string customer, string contact, DateTime date,
            DateTime expiration_Date, int version, string subject, bool show_Tax, string project, string filename,
            double price, double price_Invat, double vat_Amount) : base(id, created, modified, creator, displayName, updateHash)
        {
            Number = number;
            Customer = customer;
            Contact = contact;
            Date = date;
            Expiration_Date = expiration_Date;
            Version = version;
            Subject = subject;
            Show_Tax = show_Tax;
            Project = project;
            Filename = filename;
            Price = price;
            Price_Invat = price_Invat;
            Vat_Amount = vat_Amount;
        }

        public override string ToString()
        {
            return $"Quote\t{ID}\t{DisplayName} ";
        }
    }
}