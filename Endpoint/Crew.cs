using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve crew members and their information.
    /// </summary>
    public class Crew : AbstractEndpoint<CrewItem>
    {
        public override string Path { get => "crew"; }
        public async Task<CrewAvailabilityItem[]> GetLinkedCrewAvailabilityCollectionEntity(uint id, Filter? filter = null)
        {
            CrewAvailability? crewAvailability = Connection.Instance.GetEndpoint(typeof(CrewAvailability)) as CrewAvailability;
            if (crewAvailability == null)
                throw new NotSupportedException();
            return await crewAvailability.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Entity.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files? files = Connection.Instance.GetEndpoint(typeof(Files)) as Files;
            if (files == null)
                throw new NotSupportedException();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Appointment[]> GetLinkedAppointmentsCollectionEntity(uint id, Filter? filter = null)
        {
            Appointments? appointments = Connection.Instance.GetEndpoint(typeof(Appointments)) as Appointments;
            if (appointments == null)
                throw new NotSupportedException();
            return await appointments.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}