using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint, you could read, write, update and delete appointments.
    /// </summary>
    public class Appointments : AbstractEndpoint<Appointment>
    {
        public override string Path { get => "appointments"; }
    }
}