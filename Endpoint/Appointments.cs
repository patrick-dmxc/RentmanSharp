using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint, you could read, write, update and delete appointments.
    /// </summary>
    public class Appointments : AbstractEndpoint<Entity.Appointment, Facade.Appointment>
    {
        public override string Path { get => "appointments"; }
        public async Task<Appointment?> CreateItem(Appointment item)
        {
            return await CreateItemInternal(item);
        }
        public async Task<Appointment?> UpdateItem(Appointment item, uint id)
        {
            return await UpdateItemInternal(id, item);
        }
        public async Task DeleteItem(uint id)
        {
            await DeleteItemInternal(id);
        }

        public async Task<Facade.AppointmentCrewItem[]> GetLinkedAppointmentCrewCollectionEntity(uint id, Filter? filter = null)
        {
            AppointmentCrew appointmentCrew = Connection.Instance.GetEndpoint<AppointmentCrew>();
            return await appointmentCrew.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}