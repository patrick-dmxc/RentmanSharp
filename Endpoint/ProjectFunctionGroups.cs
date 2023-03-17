using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Function groups inside a project
    /// </summary>
    public class ProjectFunctionGroups : AbstractEndpoint<ProjectFunctionGroup>
    {
        public override string Path { get => "projectfunctiongroups"; }
        public async Task<ProjectFunction[]> GetLinkedProjectFunctionsCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectFunctions projectFunctions = Connection.Instance.GetEndpoint<ProjectFunctions>();
            return await projectFunctions.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}