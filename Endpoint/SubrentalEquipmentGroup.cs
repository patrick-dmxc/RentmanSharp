using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve information about subrental equipment groups.
    /// </summary>
    public class SubrentalEquipmentGroup : AbstractEndpoint<SubrentalEquipmentGroupItem>
    {
        public override string Path { get => "subrentalequipmentgroup"; }
    }
}