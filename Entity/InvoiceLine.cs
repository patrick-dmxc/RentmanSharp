namespace RentmanSharp.Entity
{
    public class InvoiceLine : AbstractEntity
    {
        public int Item { get; set; }
        public double Base { get; set; }
        public string? Ledger { get; set; }
        public double VatRate { get; set; }
        public double VatAmount { get; set; }
        public double PriceIncl { get; set; }
        public string? LedgerCode { get; set; }

        public override string ToString()
        {
            return $"InvoiceLine\t{ID}\t{DisplayName} {PriceIncl}EUR";
        }
    }
}
