namespace RentmanSharp.Entity
{
    public class ProjectEquipmentGroupItem : AbstractEntity
    {
        public string? Project { get; set; }
        public string? SubProject { get; set; }
        public bool Additional_Scanned { get; set; }
        public string? Name { get; set; }
        public DateTime? Usageperiod_Start { get; set; }
        public DateTime? Usageperiod_End { get; set; }
        public int Duration { get; set; }
        public DateTime? Planperiod_Start { get; set; }
        public DateTime? Planperiod_End { get; set; }
        public bool Is_Delayed { get; set; }
        public int Order { get; set; }
        public bool In_Price_Calculation { get; set; }
        public string? Remark { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
        public double Power { get; set; }
        public double Current { get; set; }
        public double Total_New_Price { get; set; }

        public override string ToString()
        {
            return $"ProjectEquipmentGroup\t{ID}\t{DisplayName} {Total_New_Price}EUR";
        }
    }
}