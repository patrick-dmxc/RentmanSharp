namespace RentmanSharp.Facade
{
    public class InvoiceLine : AbstractFacade<Entity.InvoiceLine>
    {
        public InvoiceLine() : base()
        {
        }
        internal InvoiceLine(Entity.InvoiceLine entity) : base(entity)
        {
        }
    }
}