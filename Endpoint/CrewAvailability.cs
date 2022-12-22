using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Availability of the crew members.
    /// </summary>
    public class CrewAvailability : AbstractEndpoint<CrewAvilabilityItem>
    {
        public override string Path { get => "crewavailability"; }
        public async Task<CrewAvilabilityItem?> UpdateItem(CrewAvilabilityItem item, uint id)
        {
            return await UpdateItemInternal(id, item);
        }
        public async Task DeleteItem(uint id)
        {
            await DeleteItemInternal(id);
        }
    }
}