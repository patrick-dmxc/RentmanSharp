using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents serial numbers, which are specific individual equipment pieces. This is a sub-item of Equipment and is always associated with a single Equipment item.
    /// </summary>
    public class SerialNumbers : AbstractEndpoint<SerialNumber>
    {
        public override string Path { get => "serialnumbers"; }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files? files = Connection.Instance.GetEndpoint(typeof(Files)) as Files;
            if (files == null)
                throw new NotSupportedException();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}