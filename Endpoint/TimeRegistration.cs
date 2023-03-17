using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint, you could retrieve time registrations and their information.
    /// </summary>
    public class TimeRegistration : AbstractEndpoint<TimeRegistrationItem>
    {
        public override string Path { get => "timeregistration"; }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files files = Connection.Instance.GetEndpoint<Files>();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<TimeRegistrationActivity[]> GetLinkedTimeRegistrationActivitiesCollectionEntity(uint id, Filter? filter = null)
        {
            TimeRegistrationActivities? timeRegistrationActivities = Connection.Instance.GetEndpoint<TimeRegistrationActivities>();
            return await timeRegistrationActivities.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}