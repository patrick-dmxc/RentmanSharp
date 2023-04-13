namespace RentmanSharp.Facade
{
    public class Invoice : AbstractFacade<Entity.Invoice>
    {
        public Invoice() : base()
        {
        }
        internal Invoice(Entity.Invoice entity) : base(entity)
        {
        }
    }
}