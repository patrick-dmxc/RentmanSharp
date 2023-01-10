using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve subrentals and their information.
    /// </summary>
    public class Subrentals : AbstractEndpoint<Subrental>
    {
        public override string Path { get => "subrentals"; }
        public async Task<SubrentalEquipmentGroupItem[]> GetLinkedSubrentalEquipmentGroupCollectionEntity(uint id, Filter? filter = null)
        {
            SubrentalEquipmentGroup? subrentalEquipmentGroup = Connection.Instance.GetEndpoint(typeof(SubrentalEquipmentGroup)) as SubrentalEquipmentGroup;
            if (subrentalEquipmentGroup == null)
                throw new NotSupportedException();
            return await subrentalEquipmentGroup.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files? files = Connection.Instance.GetEndpoint(typeof(Files)) as Files;
            if (files == null)
                throw new NotSupportedException();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<SubrentalEquipmentItem[]> GetLinkedSubrentalEquipmentCollectionEntity(uint id, Filter? filter = null)
        {
            SubrentalEquipment? subrentalEquipment = Connection.Instance.GetEndpoint(typeof(SubrentalEquipment)) as SubrentalEquipment;
            if (subrentalEquipment == null)
                throw new NotSupportedException();
            return await subrentalEquipment.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}