namespace RentmanSharp.Entity
{
    public class Quote : AbstractEntity
    {
        public string? Number { get; set; }
        public string? Customer { get; set; }
        public string? Contact { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Expiration_Date { get; set; }
        public int Version { get; set; }
        public string? Subject { get; set; }
        public bool Show_Tax { get; set; }
        public string? Project { get; set; }
        public string? Filename { get; set; }
        public double Price { get; set; }
        public double Price_Invat { get; set; }
        public double Vat_Amount { get; set; }

        public override string ToString()
        {
            return $"Quote\t{ID}\t{DisplayName} ";
        }
    }
}