namespace RentmanSharp.Facade
{
    public class ContactPerson : AbstractFacade<Entity.ContactPerson>
    {
        public ContactPerson() : base()
        {
        }
        internal ContactPerson(Entity.ContactPerson entity) : base(entity)
        {
        }
    }
}