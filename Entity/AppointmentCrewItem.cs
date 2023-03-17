namespace RentmanSharp.Entity
{
    public class AppointmentCrewItem : AbstractEntity
    {
        [JsonPropertyName("appointment")]
        public string? Appointment { get; }
        [JsonPropertyName("crew")]
        public string? Crew { get; }

        [JsonConstructor]
        public AppointmentCrewItem(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                                   string? updateHash, string? appointment, string? crew) : base(id, created, modified, creator, displayName, updateHash)
        {
            Appointment = appointment;
            Crew = crew;
        }

        public override string ToString()
        {
            return $"AppointmentCrew\t{ID}\t{DisplayName}";
        }
    }
}
