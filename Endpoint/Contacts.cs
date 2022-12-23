using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents a company or a private person.
    /// </summary>
    public class Contacts : AbstractEndpoint<Contact>
    {
        public override string Path { get => "contacts"; }

        private static Pagination DEFAULT_PAGINATION = new Pagination(100);
        protected override Pagination? DefaultPagination => DEFAULT_PAGINATION;
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
        public async Task<Contactperson[]> GetLinkedContactpersonsCollectionEntity(uint id, Pagination? pagination = null)
        {
            Contactpersons? contactpersons = Connection.Instance.GetEndpoint(typeof(Contactpersons)) as Contactpersons;
            if (contactpersons == null)
                throw new NotSupportedException();
            return await contactpersons.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
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