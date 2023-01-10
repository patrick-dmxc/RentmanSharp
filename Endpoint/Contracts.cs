using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents contracts.
    /// </summary>
    public class Contracts : AbstractEndpoint<Contract>
    {
        public override string Path { get => "contracts"; }
        public async Task<InvoiceLine[]> GetLinkedInvoiceLinesCollectionEntity(uint id, Filter? filter = null)
        {
            InvoiceLines? invoiceLines = Connection.Instance.GetEndpoint(typeof(InvoiceLines)) as InvoiceLines;
            if (invoiceLines == null)
                throw new NotSupportedException();
            return await invoiceLines.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files? files = Connection.Instance.GetEndpoint(typeof(Files)) as Files;
            if (files == null)
                throw new NotSupportedException();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}