using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents quotes.
    /// </summary>
    public class Quotes : AbstractEndpoint<Quote>
    {
        public override string Path { get => "quotes"; }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Pagination? pagination = null)
        {
            Files? files = Connection.Instance.GetEndpoint(typeof(Files)) as Files;
            if (files == null)
                throw new NotSupportedException();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
        public async Task<InvoiceLine[]> GetLinkedInvoiceLinesCollectionEntity(uint id, Pagination? pagination = null)
        {
            InvoiceLines? invoiceLines = Connection.Instance.GetEndpoint(typeof(InvoiceLines)) as InvoiceLines;
            if (invoiceLines == null)
                throw new NotSupportedException();
            return await invoiceLines.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
    }
}