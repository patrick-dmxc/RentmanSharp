namespace RentmanSharp.Entity
{
    public class Invoice : AbstractEntity
    {
        public string? Customer { get; set; }
        public string? Account_Manager { get; set; }
        public string? Contact { get; set; }
        public DateTime? Expiration { get; set; }
        public DateTime? Date { get; set; }
        public string? Number { get; set; }
        public double Procent { get; set; }
        public bool From_Project { get; set; }
        public string? Subject { get; set; }
        public string? Project { get; set; }
        public string? Filename { get; set; }
        public string? Tags { get; set; }

        public override string ToString()
        {
            return $"Invoice\t{ID}\t{DisplayName}";
        }
    }
}