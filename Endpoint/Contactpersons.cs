using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents a person or department within a Contact. A Person item is always associated with one Contact.
    /// </summary>
    public class ContactPersons : AbstractEndpoint<Entity.ContactPerson, Facade.ContactPerson>
    {
        public override string Path { get => "contactpersons"; }
        public async Task<ContactPerson?> UpdateItem(ContactPerson item, uint id)
        {
            return await UpdateItemInternal(id, item);
        }
        public async Task DeleteItem(uint id)
        {
            await DeleteItemInternal(id);
        }
        public async Task<Facade.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files files = Connection.Instance.GetEndpoint<Files>();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}