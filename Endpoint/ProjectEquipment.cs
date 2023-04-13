namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents equipment items planned in a project.
    /// </summary>
    public class ProjectEquipment : AbstractEndpoint<Entity.ProjectEquipmentItem, Facade.ProjectEquipmentItem>
    {
        public override string Path { get => "projectequipment"; }
    }
}