using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint, you could retrieve the activities of the time registrations and their information.
    /// </summary>
    public class TimeRegistrationActivities : AbstractEndpoint<TimeRegistrationActivity>
    {
        public override string Path { get => "timeregistrationactivities"; }
    }
}