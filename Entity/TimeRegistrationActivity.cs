namespace RentmanSharp.Entity
{
    public class TimeRegistrationActivity : AbstractEntity
    {
        public string? Time_Registration { get; set; }
        public string? Project_Function { get; set; }
        public string? Description { get; set; }
        public double Duration { get; set; }

        public override string ToString()
        {
            return $"TimeRegistrationActivity\t{ID}\t{DisplayName}";
        }
    }
}