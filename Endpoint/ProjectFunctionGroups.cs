using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Function groups inside a project
    /// </summary>
    public class ProjectFunctionGroups : AbstractEndpoint<ProjectFunctionGroup>
    {
        public override string Path { get => "projectfunctiongroups"; }
    }
}