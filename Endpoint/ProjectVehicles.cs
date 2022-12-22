using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents the vehicles planned for a function.
    /// </summary>
    public class ProjectVehicles : AbstractEndpoint<ProjectVehicle>
    {
        public override string Path { get => "projectvehicles"; }
    }
}