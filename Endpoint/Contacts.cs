using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents a company or a private person.
    /// </summary>
    public class Contacts : AbstractEndpoint<Contact>
    {
        public override string Path { get => "contacts"; }

        public static Filter DEFAULT_FILTER = new Filter(new Pagination(100));
        protected override Filter? DefaultFilter => DEFAULT_FILTER;
        public async Task<Contact?> CreateItem(Contact item)
        {
            return await CreateItemInternal(item);
        }
        public async Task<Contact?> UpdateItem(Contact item, uint id)
        {
            return await UpdateItemInternal(id, item);
        }
        public async Task DeleteItem(uint id)
        {
            await DeleteItemInternal(id);
        }
        public async Task<ContactPerson[]> GetLinkedContactpersonsCollectionEntity(uint id, Filter? filter = null)
        {
            ContactPersons contactpersons = Connection.Instance.GetEndpoint<ContactPersons>();
            return await contactpersons.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files files = Connection.Instance.GetEndpoint<Files>();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}