namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Get a specific project type.
    /// </summary>
    public class ProjectTypes : AbstractEndpoint<Entity.ProjectType, Facade.ProjectType>
    {
        public override string Path { get => "projecttypes"; }
    }
}