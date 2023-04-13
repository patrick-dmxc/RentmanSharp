namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve crew members and their information.
    /// </summary>
    public class Crew : AbstractEndpoint<Entity.CrewItem, Facade.CrewItem>
    {
        public override string Path { get => "crew"; }
        public async Task<Facade.CrewAvailabilityItem[]> GetLinkedCrewAvailabilityCollectionEntity(uint id, Filter? filter = null)
        {
            CrewAvailability crewAvailability = Connection.Instance.GetEndpoint<CrewAvailability>();
            return await crewAvailability.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files files = Connection.Instance.GetEndpoint<Files>();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.Appointment[]> GetLinkedAppointmentsCollectionEntity(uint id, Filter? filter = null)
        {
            Appointments appointments = Connection.Instance.GetEndpoint<Appointments>();
            return await appointments.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}