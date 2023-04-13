namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint, you could retrieve which crew member is linked to an appointment
    /// </summary>
    public class AppointmentCrew : AbstractEndpoint<Entity.AppointmentCrewItem, Facade.AppointmentCrewItem>
    {
        public override string Path { get => "appointmentcrew"; }
    }
}