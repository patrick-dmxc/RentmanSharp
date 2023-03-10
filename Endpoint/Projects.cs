using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Projects are the cornerstone of Rentman. Projects are connected to many other items. Projects always include one or more subprojects. When the user interface does not show any subprojects there is in fact a single one. See the /subprojects endpoint for more information.
    /// </summary>
    public class Projects : AbstractEndpoint<Project>
    {
        public override string Path { get => "projects"; }

        public static Filter DEFAULT_FILTER = new Filter(new Pagination(100));
        protected override Filter? DefaultFilter => DEFAULT_FILTER;
        public async Task<Cost[]> GetLinkedCostsCollectionEntity(uint id, Filter? filter = null)
        {
            Costs? costs = Connection.Instance.GetEndpoint(typeof(Costs)) as Costs;
            if (costs == null)
                throw new NotSupportedException();
            return await costs.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<ProjectFunction[]> GetLinkedProjectFunctionsCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectFunctions? projectFunctions = Connection.Instance.GetEndpoint(typeof(ProjectFunctions)) as ProjectFunctions;
            if (projectFunctions == null)
                throw new NotSupportedException();
            return await projectFunctions.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<SubProject[]> GetLinkedSubProjectsCollectionEntity(uint id, Filter? filter = null)
        {
            SubProjects? subProjects = Connection.Instance.GetEndpoint(typeof(SubProjects)) as SubProjects;
            if (subProjects == null)
                throw new NotSupportedException();
            return await subProjects.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<ProjectFunctionGroup[]> GetLinkedProjectFunctionGroupsCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectFunctionGroups? projectFunctionGroups = Connection.Instance.GetEndpoint(typeof(ProjectFunctionGroups)) as ProjectFunctionGroups;
            if (projectFunctionGroups == null)
                throw new NotSupportedException();
            return await projectFunctionGroups.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Quote[]> GetLinkedQuotesCollectionEntity(uint id, Filter? filter = null)
        {
            Quotes? quotes = Connection.Instance.GetEndpoint(typeof(Quotes)) as Quotes;
            if (quotes == null)
                throw new NotSupportedException();
            return await quotes.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files? files = Connection.Instance.GetEndpoint(typeof(Files)) as Files;
            if (files == null)
                throw new NotSupportedException();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<ProjectVehicle[]> GetLinkedProjectVehiclesCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectVehicles? projectVehicles = Connection.Instance.GetEndpoint(typeof(ProjectVehicles)) as ProjectVehicles;
            if (projectVehicles == null)
                throw new NotSupportedException();
            return await projectVehicles.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<ProjectCrewItem[]> GetLinkedProjectCrewCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectCrew? projectCrew = Connection.Instance.GetEndpoint(typeof(ProjectCrew)) as ProjectCrew;
            if (projectCrew == null)
                throw new NotSupportedException();
            return await projectCrew.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<ProjectEquipmentItem[]> GetLinkedProjectEquipmentCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectEquipment? projectEquipment = Connection.Instance.GetEndpoint(typeof(ProjectEquipment)) as ProjectEquipment;
            if (projectEquipment == null)
                throw new NotSupportedException();
            return await projectEquipment.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}