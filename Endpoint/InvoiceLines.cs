using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Invoice lines are the individual lines denoting an entry on an invoice.
    /// </summary>
    public class InvoiceLines : AbstractEndpoint<InvoiceLine>
    {
        public override string Path { get => "invoicelines"; }
    }
}