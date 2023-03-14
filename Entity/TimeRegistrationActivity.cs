using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class TimeRegistrationActivity : AbstractEntity
    {
        [JsonPropertyName("time_registration")]
        public string? Time_Registration { get; }
        [JsonPropertyName("project_function")]
        public string? Project_Function { get; }
        [JsonPropertyName("description")]
        public string? Description { get; }
        [JsonPropertyName("duration")]
        public double Duration { get; }

        [JsonConstructor]
        public TimeRegistrationActivity(
            uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName, string? updateHash,
            string? time_Registration, string? project_Function, string? description, double duration) : base(id, created, modified, creator, displayName, updateHash)
        {
            Time_Registration = time_Registration;
            Project_Function = project_Function;
            Description = description;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"TimeRegistrationActivity\t{ID}\t{DisplayName}";
        }
    }
}