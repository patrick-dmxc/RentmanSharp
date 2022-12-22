namespace RentmanSharp.Entity
{
    public class Status : AbstractEntity
    {
        public string? Name { get; set; }

        public override string ToString()
        {
            return $"Status\t{ID}\t{DisplayName}";
        }
    }
}