namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Function groups inside a project
    /// </summary>
    public class ProjectFunctionGroups : AbstractEndpoint<Entity.ProjectFunctionGroup, Facade.ProjectFunctionGroup>
    {
        public override string Path { get => "projectfunctiongroups"; }
        public async Task<Facade.ProjectFunction[]> GetLinkedProjectFunctionsCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectFunctions projectFunctions = Connection.Instance.GetEndpoint<ProjectFunctions>();
            return await projectFunctions.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}