namespace RentmanSharp.Entity
{
    public abstract class AbstractEntity : IEntity
    {
        public uint? ID { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string? Creator { get; set; }
        public string? DisplayName { get; set; }
        public string? updateHash { get; set; }

        public override string ToString()
        {
            return $"{ID}\t{DisplayName}";
        }
        public override int GetHashCode()
        {
            return (ID?.GetHashCode() ?? 0) + (updateHash?.GetHashCode() ?? 0);
        }
    }
}
