namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// A function is a task that needs to be performed. Functions are connected to subprojects (and projects). Functions can be grouped inside function groups.
    /// </summary>
    public class ProjectFunctions : AbstractEndpoint<Entity.ProjectFunction, Facade.ProjectFunction>
    {
        public override string Path { get => "projectfunctions"; }
        public async Task<Facade.ProjectCrewItem[]> GetLinkedProjectCrewCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectCrew projectCrew = Connection.Instance.GetEndpoint<ProjectCrew>();
            return await projectCrew.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.ProjectVehicle[]> GetLinkedProjectVehiclesCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectVehicles projectVehicles = Connection.Instance.GetEndpoint<ProjectVehicles>();
            return await projectVehicles.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}