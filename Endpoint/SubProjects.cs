using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Stock movements are all the changes that happen to the stock levels of an equipment. Those changes include manual changes, purchases, sales, transfers, stock corrections, repairs, marking lost or found, imports, stock counts. When creating or updating stock movements via the API only stock movements of type 'manual' are writable. Only stock movements for bulk items are available though the API. Stock movements for serialized equipment may be implemented at a later stage.
    /// </summary>
    public class SubProjects : AbstractEndpoint<SubProject>
    {
        public override string Path { get => "subprojects"; }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files files = Connection.Instance.GetEndpoint<Files>();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<ProjectVehicle[]> GetLinkedProjectVehiclesCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectVehicles projectVehicles = Connection.Instance.GetEndpoint<ProjectVehicles>();
            return await projectVehicles.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<ProjectEquipmentGroupItem[]> GetLinkedProjectEquipmentGroupCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectEquipmentGroup projectEquipmentGroup = Connection.Instance.GetEndpoint<ProjectEquipmentGroup>();
            return await projectEquipmentGroup.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<ProjectCrewItem[]> GetLinkedProjectCrewCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectCrew projectCrew = Connection.Instance.GetEndpoint<ProjectCrew>();
            return await projectCrew.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<ProjectEquipmentItem[]> GetLinkedProjectEquipmentCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectEquipment projectEquipment = Connection.Instance.GetEndpoint<ProjectEquipment>();
            return await projectEquipment.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<ProjectFunctionGroup[]> GetLinkedProjectFunctionGroupsCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectFunctionGroups projectFunctionGroups = Connection.Instance.GetEndpoint<ProjectFunctionGroups>();
            return await projectFunctionGroups.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}