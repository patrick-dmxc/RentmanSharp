namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents the vehicles planned for a function.
    /// </summary>
    public class ProjectVehicles : AbstractEndpoint<Entity.ProjectVehicle, Facade.ProjectVehicle>
    {
        public override string Path { get => "projectvehicles"; }
    }
}