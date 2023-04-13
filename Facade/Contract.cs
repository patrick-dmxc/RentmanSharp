namespace RentmanSharp.Facade
{
    public class Contract : AbstractFacade<Entity.Contract>
    {
        public Contract() : base()
        {
        }
        internal Contract(Entity.Contract entity) : base(entity)
        {
        }
    }
}