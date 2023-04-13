namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Invoice lines are the individual lines denoting an entry on an invoice.
    /// </summary>
    public class InvoiceLines : AbstractEndpoint<Entity.InvoiceLine, Facade.InvoiceLine>
    {
        public override string Path { get => "invoicelines"; }
    }
}