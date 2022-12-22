using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// A function is a task that needs to be performed. Functions are connected to subprojects (and projects). Functions can be grouped inside function groups.
    /// </summary>
    public class ProjectFunctions : AbstractEndpoint<ProjectFunction>
    {
        public override string Path { get => "projectfunctions"; }
    }
}