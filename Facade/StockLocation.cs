namespace RentmanSharp.Facade
{
    public class StockLocation : AbstractFacade<Entity.StockLocation>
    {
        public StockLocation() : base()
        {
        }
        internal StockLocation(Entity.StockLocation entity) : base(entity)
        {
        }
    }
}