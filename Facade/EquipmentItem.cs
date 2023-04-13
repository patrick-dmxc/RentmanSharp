namespace RentmanSharp.Facade
{
    public class EquipmentItem : AbstractFacade<Entity.EquipmentItem>
    {
        public EquipmentItem() : base()
        {
        }
        internal EquipmentItem(Entity.EquipmentItem entity) : base(entity)
        {
        }
    }
}