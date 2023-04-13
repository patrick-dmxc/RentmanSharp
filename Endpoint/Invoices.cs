namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents invoices.
    /// </summary>
    public class Invoices : AbstractEndpoint<Entity.Invoice, Facade.Invoice>
    {
        public override string Path { get => "invoices"; }
        public async Task<Facade.InvoiceLine[]> GetLinkedInvoiceLinesCollectionEntity(uint id, Filter? filter = null)
        {
            InvoiceLines invoiceLines = Connection.Instance.GetEndpoint<InvoiceLines>();
            return await invoiceLines.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files files = Connection.Instance.GetEndpoint<Files>();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}