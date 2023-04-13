namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve subrentals and their information.
    /// </summary>
    public class Subrentals : AbstractEndpoint<Entity.Subrental, Facade.Subrental>
    {
        public override string Path { get => "subrentals"; }
        public async Task<Facade.SubrentalEquipmentGroupItem[]> GetLinkedSubrentalEquipmentGroupCollectionEntity(uint id, Filter? filter = null)
        {
            SubrentalEquipmentGroup subrentalEquipmentGroup = Connection.Instance.GetEndpoint<SubrentalEquipmentGroup>();
            return await subrentalEquipmentGroup.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files? files = Connection.Instance.GetEndpoint<Files>();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.SubrentalEquipmentItem[]> GetLinkedSubrentalEquipmentCollectionEntity(uint id, Filter? filter = null)
        {
            SubrentalEquipment subrentalEquipment = Connection.Instance.GetEndpoint<SubrentalEquipment>();
            return await subrentalEquipment.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}