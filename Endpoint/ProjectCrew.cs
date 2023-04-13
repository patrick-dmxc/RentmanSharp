namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents the planning of crewmembers on Functions
    /// </summary>
    public class ProjectCrew : AbstractEndpoint<Entity.ProjectCrewItem, Facade.ProjectCrewItem>
    {
        public override string Path { get => "projectcrew"; }
    }
}