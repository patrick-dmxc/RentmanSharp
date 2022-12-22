using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint, you could retrieve time registrations and their information.
    /// </summary>
    public class TimeRegistration : AbstractEndpoint<TimeRegistrationItem>
    {
        public override string Path { get => "timeregistration"; }
    }
}