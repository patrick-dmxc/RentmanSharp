using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve crew members and their information.
    /// </summary>
    public class Crew : AbstractEndpoint<CrewItem>
    {
        public override string Path { get => "crew"; }
    }
}