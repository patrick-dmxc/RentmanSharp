namespace RentmanSharp.Facade
{
    public class SerialNumber : AbstractFacade<Entity.SerialNumber>
    {
        public SerialNumber() : base()
        {
        }
        internal SerialNumber(Entity.SerialNumber entity) : base(entity)
        {
        }
    }
}