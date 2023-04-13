namespace RentmanSharp.Facade
{
    public class Status : AbstractFacade<Entity.Status>
    {
        public Status() : base()
        {
        }
        internal Status(Entity.Status entity) : base(entity)
        {
        }
    }
}