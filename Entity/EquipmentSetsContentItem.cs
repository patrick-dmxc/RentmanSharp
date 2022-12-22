namespace RentmanSharp.Entity
{
    public class EquipmentSetsContentItem : AbstractEntity
    {
        public int Quantity { get; set; }
        public string? Parent_Equipment { get; set; }
        public int Order { get; set; }
        public string? Equipment { get; set; }

        public override string ToString()
        {
            return $"EquipmentSetsContent\t{ID}\t{DisplayName}";
        }
    }
}