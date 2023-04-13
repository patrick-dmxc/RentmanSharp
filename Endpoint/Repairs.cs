namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve repairs and their information.
    /// </summary>
    public class Repairs : AbstractEndpoint<Entity.Repair, Facade.Repair>
    {
        public override string Path { get => "repairs"; }
        public async Task<Facade.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files files = Connection.Instance.GetEndpoint<Files>();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}