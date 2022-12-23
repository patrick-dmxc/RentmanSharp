using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Function groups inside a project
    /// </summary>
    public class ProjectFunctionGroups : AbstractEndpoint<ProjectFunctionGroup>
    {
        public override string Path { get => "projectfunctiongroups"; }
        public async Task<ProjectFunction[]> GetLinkedProjectFunctionsCollectionEntity(uint id, Pagination? pagination = null)
        {
            ProjectFunctions? projectFunctions = Connection.Instance.GetEndpoint(typeof(ProjectFunctions)) as ProjectFunctions;
            if (projectFunctions == null)
                throw new NotSupportedException();
            return await projectFunctions.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
    }
}