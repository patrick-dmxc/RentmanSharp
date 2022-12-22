using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Get a specific project type.
    /// </summary>
    public class ProjectTypes : AbstractEndpoint<ProjectType>
    {
        public override string Path { get => "projecttypes"; }
    }
}