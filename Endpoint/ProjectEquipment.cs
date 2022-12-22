using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents equipment items planned in a project.
    /// </summary>
    public class ProjectEquipment : AbstractEndpoint<ProjectEquipmentItem>
    {
        public override string Path { get => "projectequipment"; }
    }
}