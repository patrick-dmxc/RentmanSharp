using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Stock movements are all the changes that happen to the stock levels of an equipment. Those changes include manual changes, purchases, sales, transfers, stock corrections, repairs, marking lost or found, imports, stock counts. When creating or updating stock movements via the API only stock movements of type 'manual' are writable. Only stock movements for bulk items are available though the API. Stock movements for serialized equipment may be implemented at a later stage.
    /// </summary>
    public class SubProjects : AbstractEndpoint<SubProject>
    {
        public override string Path { get => "subprojects";
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Pagination? pagination = null)
        {
            Files? files = Connection.Instance.GetEndpoint(typeof(Files)) as Files;
            if (files == null)
                throw new NotSupportedException();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
        public async Task<ProjectVehicle[]> GetLinkedProjectVehiclesCollectionEntity(uint id, Pagination? pagination = null)
        {
            ProjectVehicles? projectVehicles = Connection.Instance.GetEndpoint(typeof(ProjectVehicles)) as ProjectVehicles;
            if (projectVehicles == null)
                throw new NotSupportedException();
            return await projectVehicles.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
        public async Task<ProjectEquipmentGroupItem[]> GetLinkedProjectEquipmentGroupCollectionEntity(uint id, Pagination? pagination = null)
        {
            ProjectEquipmentGroup? projectEquipmentGroup = Connection.Instance.GetEndpoint(typeof(ProjectEquipmentGroup)) as ProjectEquipmentGroup;
            if (projectEquipmentGroup == null)
                throw new NotSupportedException();
            return await projectEquipmentGroup.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
        public async Task<ProjectCrewItem[]> GetLinkedProjectCrewCollectionEntity(uint id, Pagination? pagination = null)
        {
            ProjectCrew? projectCrew = Connection.Instance.GetEndpoint(typeof(ProjectCrew)) as ProjectCrew;
            if (projectCrew == null)
                throw new NotSupportedException();
            return await projectCrew.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
        public async Task<ProjectEquipmentItem[]> GetLinkedProjectEquipmentCollectionEntity(uint id, Pagination? pagination = null)
        {
            ProjectEquipment? projectEquipment = Connection.Instance.GetEndpoint(typeof(ProjectEquipment)) as ProjectEquipment;
            if (projectEquipment == null)
                throw new NotSupportedException();
            return await projectEquipment.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
        public async Task<ProjectFunctionGroup[]> GetLinkedProjectFunctionGroupsCollectionEntity(uint id, Pagination? pagination = null)
        {
            ProjectFunctionGroups? projectFunctionGroups = Connection.Instance.GetEndpoint(typeof(ProjectFunctionGroups)) as ProjectFunctionGroups;
            if (projectFunctionGroups == null)
                throw new NotSupportedException();
            return await projectFunctionGroups.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
    }
}