using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve repairs and their information.
    /// </summary>
    public class Repairs : AbstractEndpoint<Repair>
    {
        public override string Path { get => "repairs"; }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files? files = Connection.Instance.GetEndpoint(typeof(Files)) as Files;
            if (files == null)
                throw new NotSupportedException();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}