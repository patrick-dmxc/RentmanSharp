namespace RentmanSharp.Facade
{
    public class Rate : AbstractFacade<Entity.Rate>
    {
        public Rate() : base()
        {
        }
        internal Rate(Entity.Rate entity) : base(entity)
        {
        }
    }
}