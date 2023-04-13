namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Projects are the cornerstone of Rentman. Projects are connected to many other items. Projects always include one or more subprojects. When the user interface does not show any subprojects there is in fact a single one. See the /subprojects endpoint for more information.
    /// </summary>
    public class Projects : AbstractEndpoint<Entity.Project, Facade.Project>
    {
        public override string Path { get => "projects"; }

        public static Filter DEFAULT_FILTER = new Filter(new Pagination(100));
        protected override Filter? DefaultFilter => DEFAULT_FILTER;
        public async Task<Facade.Cost[]> GetLinkedCostsCollectionEntity(uint id, Filter? filter = null)
        {
            Costs costs = Connection.Instance.GetEndpoint<Costs>();
            return await costs.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.ProjectFunction[]> GetLinkedProjectFunctionsCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectFunctions projectFunctions = Connection.Instance.GetEndpoint<ProjectFunctions>();
            return await projectFunctions.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.SubProject[]> GetLinkedSubProjectsCollectionEntity(uint id, Filter? filter = null)
        {
            SubProjects subProjects = Connection.Instance.GetEndpoint<SubProjects>();
            return await subProjects.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.ProjectFunctionGroup[]> GetLinkedProjectFunctionGroupsCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectFunctionGroups projectFunctionGroups = Connection.Instance.GetEndpoint<ProjectFunctionGroups>();
            return await projectFunctionGroups.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.Quote[]> GetLinkedQuotesCollectionEntity(uint id, Filter? filter = null)
        {
            Quotes quotes = Connection.Instance.GetEndpoint<Quotes>();
            return await quotes.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files files = Connection.Instance.GetEndpoint<Files>();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.ProjectVehicle[]> GetLinkedProjectVehiclesCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectVehicles projectVehicles = Connection.Instance.GetEndpoint<ProjectVehicles>();
            return await projectVehicles.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.ProjectCrewItem[]> GetLinkedProjectCrewCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectCrew projectCrew = Connection.Instance.GetEndpoint<ProjectCrew>();
            return await projectCrew.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.ProjectEquipmentItem[]> GetLinkedProjectEquipmentCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectEquipment projectEquipment = Connection.Instance.GetEndpoint<ProjectEquipment>();
            return await projectEquipment.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}