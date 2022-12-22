namespace RentmanSharp.Entity
{
    public class SubrentalEquipmentItem : AbstractEntity
    {
        public string? Subrental_Group { get; set; }
        public string? Equipment { get; set; }
        public string? Parent { get; set; }
        public DateTime? Planperiod_Start { get; set; }
        public DateTime? Planperiod_End { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public int Quantity_Total { get; set; }
        public double Unit_Price { get; set; }
        public double Discount { get; set; }
        public double Factor { get; set; }
        public int Order { get; set; }
        public string? Remark { get; set; }
        public double LinePrice { get; set; }
        public string? Supplier_PlanningMateriaal { get; set; }

        public override string ToString()
        {
            return $"SubrentalEquipment\t{ID}\t{Quantity}x\t{DisplayName}\t{LinePrice}";
        }
    }
}