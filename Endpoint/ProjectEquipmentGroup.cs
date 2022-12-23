using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Equipment groups of a project.
    /// </summary>
    public class ProjectEquipmentGroup : AbstractEndpoint<ProjectEquipmentGroupItem>
    {
        public override string Path { get => "projectequipmentgroup"; }
        public async Task<ProjectEquipmentItem[]> GetLinkedProjectEquipmentCollectionEntity(uint id, Pagination? pagination = null)
        {
            ProjectEquipment? projectEquipment = Connection.Instance.GetEndpoint(typeof(ProjectEquipment)) as ProjectEquipment;
            if (projectEquipment == null)
                throw new NotSupportedException();
            return await projectEquipment.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
    }
}