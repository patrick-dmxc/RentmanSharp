namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve information about subrental equipment groups.
    /// </summary>
    public class SubrentalEquipmentGroup : AbstractEndpoint<Entity.SubrentalEquipmentGroupItem, Facade.SubrentalEquipmentGroupItem>
    {
        public override string Path { get => "subrentalequipmentgroup"; }
        public async Task<Facade.SubrentalEquipmentItem[]> GetLinkedSubrentalEquipmentCollectionEntity(uint id, Filter? filter = null)
        {
            SubrentalEquipment subrentalEquipment = Connection.Instance.GetEndpoint<SubrentalEquipment>();
            return await subrentalEquipment.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}