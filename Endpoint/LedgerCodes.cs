namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Ledger codes are the codes defining the type of trade for an invoice line.
    /// </summary>
    public class LedgerCodes : AbstractEndpoint<Entity.LedgerCode, Facade.LedgerCode>
    {
        public override string Path { get => "ledgercodes"; }
    }
}