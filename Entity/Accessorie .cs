namespace RentmanSharp.Entity
{
    public class Accessorie : AbstractEntity
    {
        public string? Parent_Equipment { get; set; }
        public string? Equipment { get; set; }
        public int Quantity { get; set; }
        public bool Automatic { get; set; }

        public override string ToString()
        {
            return $"Accessorie\t{ID}\t{DisplayName}";
        }
    }
}
