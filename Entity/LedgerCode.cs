namespace RentmanSharp.Entity
{
    public class LedgerCode : AbstractEntity
    {
        public string? Code { get; set; }

        public override string ToString()
        {
            return $"LedgerCode\t{ID}\t{DisplayName}";
        }
    }
}