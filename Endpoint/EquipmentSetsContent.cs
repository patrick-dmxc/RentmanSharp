namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint, you can retrieve the contents of kits and cases together with their information.
    /// </summary>
    public class EquipmentSetsContent : AbstractEndpoint<Entity.EquipmentSetsContentItem, Facade.EquipmentSetsContentItem>
    {
        public override string Path { get => "equipmentsetscontent"; }
    }
}