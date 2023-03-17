namespace RentmanSharp.Entity
{
    public class InvoiceLine : AbstractEntity
    {
        [JsonPropertyName("item")]
        public int Item { get; }
        [JsonPropertyName("base")]
        public double Base { get; }
        [JsonPropertyName("ledger")]
        public string Ledger { get; }
        [JsonPropertyName("vatrate")]
        public double VatRate { get; }
        [JsonPropertyName("vatamount")]
        public double VatAmount { get; }
        [JsonPropertyName("priceincl")]
        public double PriceIncl { get; }
        [JsonPropertyName("ledgercode")]
        public string LedgerCode { get; }

        [JsonConstructor]
        public InvoiceLine(uint id, DateTime created, DateTime modified, string creator, string displayName,
            string updateHash, int item, double @base, string ledger, double vatRate, double vatAmount,
            double priceIncl, string ledgerCode) : base(id, created, modified, creator, displayName, updateHash)
        {
            Item = item;
            Base = @base;
            Ledger = ledger;
            VatRate = vatRate;
            VatAmount = vatAmount;
            PriceIncl = priceIncl;
            LedgerCode = ledgerCode;
        }

        public override string ToString()
        {
            return $"InvoiceLine\t{ID}\t{DisplayName} {PriceIncl}EUR";
        }
    }
}
