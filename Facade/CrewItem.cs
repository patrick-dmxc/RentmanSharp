namespace RentmanSharp.Facade
{
    public class CrewItem : AbstractFacade<Entity.CrewItem>
    {
        public CrewItem() : base()
        {
        }
        internal CrewItem(Entity.CrewItem entity) : base(entity)
        {
        }
    }
}