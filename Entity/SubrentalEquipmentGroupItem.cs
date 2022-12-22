namespace RentmanSharp.Entity
{
    public class SubrentalEquipmentGroupItem : AbstractEntity
    {
        public string? Subrental { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }
        public string? Supplier_Category { get; set; }

        public override string ToString()
        {
            return $"SubrentalEquipmentGroup\t{ID}\t{DisplayName}";
        }
    }
}