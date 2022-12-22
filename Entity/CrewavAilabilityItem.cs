namespace RentmanSharp.Entity
{
    public class CrewavAilabilityItem : AbstractEntity
    {
        public string? Last_Updater { get; set; }
        public string? Last_Updated { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? CrewMember { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }

        public override string ToString()
        {
            return $"CrewavAilability\t{ID}\t{DisplayName} {Status}";
        }
    }
}
