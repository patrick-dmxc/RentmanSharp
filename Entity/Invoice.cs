namespace RentmanSharp.Entity
{
    public class Invoice : AbstractEntity
    {

        [JsonPropertyName("customer")]
        public string? Customer { get; }
        [JsonPropertyName("account_manager")]
        public string? Account_Manager { get; }
        [JsonPropertyName("contact")]
        public string? Contact { get; }
        [JsonPropertyName("expiration")]
        public DateTime? Expiration { get; }
        [JsonPropertyName("date")]
        public DateTime? Date { get; }
        [JsonPropertyName("number")]
        public string? Number { get; }
        [JsonPropertyName("procent")]
        public double Procent { get; }
        [JsonPropertyName("from_project")]
        public bool From_Project { get; }
        [JsonPropertyName("subject")]
        public string? Subject { get; }
        [JsonPropertyName("project")]
        public string? Project { get; }
        [JsonPropertyName("filename")]
        public string? Filename { get; }
        [JsonPropertyName("tags")]
        public string? Tags { get; }

        [JsonConstructor]
        public Invoice(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
            string? updateHash, string? customer, string? account_Manager, string? contact, DateTime? expiration,
            DateTime? date, string? number, double procent, bool from_Project, string? subject, string? project,
            string? filename, string? tags) : base(id, created, modified, creator, displayName, updateHash)
        {
            Customer = customer;
            Account_Manager = account_Manager;
            Contact = contact;
            Expiration = expiration;
            Date = date;
            Number = number;
            Procent = procent;
            From_Project = from_Project;
            Subject = subject;
            Project = project;
            Filename = filename;
            Tags = tags;
        }

        public override string ToString()
        {
            return $"Invoice\t{ID}\t{DisplayName}";
        }
    }
}