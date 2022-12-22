namespace RentmanSharp.Entity
{
    public class AppointmentCrewItem : AbstractEntity
    {
        public string? Appointment { get; set; }
        public string? Crew { get; set; }

        public override string ToString()
        {
            return $"AppointmentCrew\t{ID}\t{DisplayName}";
        }
    }
}
