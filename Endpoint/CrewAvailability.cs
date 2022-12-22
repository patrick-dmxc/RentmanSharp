using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Availability of the crew members.
    /// </summary>
    public class CrewAvailability : AbstractEndpoint<CrewavAilabilityItem>
    {
        public override string Path { get => "crewavailability"; }
    }
}