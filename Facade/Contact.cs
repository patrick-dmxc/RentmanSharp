namespace RentmanSharp.Facade
{
    public class Contact : AbstractFacade<Entity.Contact>
    {
        public Contact() : base()
        {
        }
        internal Contact(Entity.Contact entity) : base(entity)
        {
        }
    }
}