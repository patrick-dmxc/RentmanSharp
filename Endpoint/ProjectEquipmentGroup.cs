using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Equipment groups of a project.
    /// </summary>
    public class ProjectEquipmentGroup : AbstractEndpoint<ProjectEquipmentGroupItem>
    {
        public override string Path { get => "projectequipmentgroup"; }
    }
}