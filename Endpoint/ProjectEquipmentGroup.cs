using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Equipment groups of a project.
    /// </summary>
    public class ProjectEquipmentGroup : AbstractEndpoint<ProjectEquipmentGroupItem>
    {
        public override string Path { get => "projectequipmentgroup"; }
        public async Task<ProjectEquipmentItem[]> GetLinkedProjectEquipmentCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectEquipment projectEquipment = Connection.Instance.GetEndpoint<ProjectEquipment>();
            return await projectEquipment.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}