namespace RentmanSharp.Facade
{
    public class StockMovement : AbstractFacade<Entity.StockMovement>
    {
        public StockMovement() : base()
        {
        }
        internal StockMovement(Entity.StockMovement entity) : base(entity)
        {
        }
    }
}