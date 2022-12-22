namespace RentmanSharp.Entity
{
    public class RateFactor : AbstractEntity
    {
        public string? Rate_ID { get; set; }
        public string? Name { get; set; }
        public double From { get; set; }
        public double To { get; set; }
        public double Variable { get; set; }
        public double Fixed { get; set; }

        public override string ToString()
        {
            return $"RateFactor\t{ID}\t{DisplayName} V:{Variable}\tF:{Fixed}\t{From}\t-\t{To}";
        }
    }
}