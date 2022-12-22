namespace RentmanSharp.Entity
{
    public class Contract : AbstractEntity
    {
        public string? Number { get; set; }
        public string? Customer { get; set; }
        public string? Contact { get; set; }
        public string? Date { get; set; }
        public string? Expiration_Date { get; set; }
        public int Version { get; set; }
        public string? Subject { get; set; }
        public bool Show_Tax { get; set; }
        public string? Project { get; set; }
        public string? Filename { get; set; }
        public double Price { get; set; }
        public double Price_Invat { get; set; }
        public double VAT_Amount { get; set; }

        public override string ToString()
        {
            return $"Contract\t{ID}\t{DisplayName} {Price}EUR";
        }
    }
}