using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Ledger codes are the codes defining the type of trade for an invoice line.
    /// </summary>
    public class LedgerCodes : AbstractEndpoint<LedgerCode>
    {
        public override string Path { get => "ledgercodes"; }
    }
}