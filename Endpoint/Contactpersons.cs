using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents a person or department within a Contact. A Person item is always associated with one Contact.
    /// </summary>
    public class Contactpersons : AbstractEndpoint<Contactperson>
    {
        public override string Path { get => "contactpersons"; }
        public async Task<Contactperson?> UpdateItem(Contactperson item, uint id)
        {
            return await UpdateItemInternal(id, item);
        }
        public async Task DeleteItem(uint id)
        {
            await DeleteItemInternal(id);
        }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Pagination? pagination = null)
        {
            Files? files = Connection.Instance.GetEndpoint(typeof(Files)) as Files;
            if (files == null)
                throw new NotSupportedException();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
    }
}