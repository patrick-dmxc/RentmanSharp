namespace RentmanSharp.Entity
{
    public class ProjectRequestEquipmentItem : AbstractEntity
    {
        public int Quantity { get; set; }
        public int Quantity_Total { get; set; }
        public bool Is_Comment { get; set; }
        public bool Is_Kit { get; set; }
        public double Discount { get; set; }
        public string? Linked_Equipment { get; set; }
        public string? Name { get; set; }
        public string? External_Remark { get; set; }
        public string? Parent { get; set; }
        public double Unit_Price { get; set; }
        public string? Parent_Request { get; set; }
        public double Factor { get; set; }
        public int Order { get; set; }

        public override string ToString()
        {
            return $"ProjectRequestEquipment\t{ID}\t{Quantity}x\t{DisplayName} ";
        }
    }
}