namespace RentmanSharp.Facade
{
    public class Quote : AbstractFacade<Entity.Quote>
    {
        public Quote() : base()
        {
        }
        internal Quote(Entity.Quote entity) : base(entity)
        {
        }
    }
}