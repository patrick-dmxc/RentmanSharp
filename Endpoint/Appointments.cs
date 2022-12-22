using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint, you could read, write, update and delete appointments.
    /// </summary>
    public class Appointments : AbstractEndpoint<Appointment>
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
    }
}