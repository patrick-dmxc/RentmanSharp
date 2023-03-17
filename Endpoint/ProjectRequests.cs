using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Project Requests are incoming requests from external sources that allows you to turn into projects. These could come from another Rentman user, that is using the internal subrent request feature. By making also the POST endpoint available in the API, you can now also push these from other applications. For example from your CRM system, a form on your website, or any other source. The benefit of using Project Requests is that you can provide the data in a raw format. While converting a Project Request into a project from the Rentman interface, you can match this data to existing contacts, equipments etc. No need to set up complicated logic to fetch these items using the API first.
    /// </summary>
    public class ProjectRequests : AbstractEndpoint<ProjectRequest>
    {
        public override string Path { get => "projectrequests"; }
        public async Task<ProjectRequest?> CreateItem(ProjectRequest item)
        {
            return await CreateItemInternal(item);
        }
        public async Task<ProjectRequest?> UpdateItem(ProjectRequest item, uint id)
        {
            return await UpdateItemInternal(id, item);
        }
        public async Task DeleteItem(uint id)
        {
            await DeleteItemInternal(id);
        }
        public async Task<ProjectRequestEquipmentItem[]> GetLinkedProjectRequestEquipmentCollectionEntity(uint id, Filter? filter = null)
        {
            ProjectRequestEquipment projectRequestEquipment = Connection.Instance.GetEndpoint<ProjectRequestEquipment>();
            return await projectRequestEquipment.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}